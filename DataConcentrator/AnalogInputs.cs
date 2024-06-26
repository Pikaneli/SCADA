using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace DataConcentrator
{
    public delegate void AlarmActivatedHandler(string id, string tagName, string message, DateTime t);
    public class AnalogInputs : Zajednicka
    {
        #region Field
        private bool on_off_scan;
        private double low_limit;
        private double high_limit;
        private string units;
        private string poruka;
        private int scan_time;
        private object locker = new object();
        private object alarmlock = new object();
        public static event AlarmActivatedHandler AlarmActivated;
        private List<Alarms> aktivni;
        #endregion
        #region Properites
        public bool On_off_scan
        {
            get { return on_off_scan; }
            set
            {
                if (on_off_scan != value)
                {
                    on_off_scan = value;
                    OnPropertyChanged("On_off_scan");
                }
            }
        }

        public double Low_limit
        {
            get { return low_limit; }
            set
            {
                if (low_limit != value)
                {
                    low_limit = value;
                    OnPropertyChanged("Low_limit");
                }
            }
        }

        public double High_limit
        {
            get { return high_limit; }
            set
            {
                if (high_limit != value)
                {
                    high_limit = value;
                    OnPropertyChanged("High_limit");
                }
            }
        }

        public string Units
        {
            get { return units; }
            set
            {
                if (units != value)
                {
                    units = value;
                    OnPropertyChanged("Units");
                }
            }
        }
        public int Scan_time
        {
            get { return scan_time; }
            set
            {
                if (scan_time != value)
                {
                    scan_time = value;
                    OnPropertyChanged("Scan_time");
                }
            }
        }
        public string Poruka
        {
            get { return poruka; }
            set
            {
                if (poruka != value)
                {
                    poruka = value;
                    OnPropertyChanged("Poruka");
                }
            }
        }
        #endregion

        public virtual List<Alarms> Alarmi { get; set; }

        public void Start_nit()
        {
            Thread t = new Thread(() => scan());
            PLCInstance.tagsThreads.Add(IO_adress, t);
            t.Start();
        }

        private void scan()
        {
            while (true)
            {
                lock (locker)
                {
                    if (on_off_scan)
                    {
                       
                        double pom = PLCInstance.Instance.GetAnalogValue(IO_adress);
                        if (pom > High_limit)
                        {
                            Current_value = High_limit;
                        }
                        else if(pom < Low_limit)
                        {
                            Current_value = Low_limit;
                        }
                        else
                        {
                            Current_value = pom;
                        }
                    }
                }
                Thread.Sleep(Scan_time);
                lock (alarmlock)
                {
                    if (Alarmi == null)
                    {
                        Alarmi = new List<Alarms>();
                    }
                    if (aktivni == null)
                    {
                        aktivni = new List<Alarms>();
                    }
                    foreach(Alarms a in Alarmi)
                    {
                        if (a.H_l) // vece od limita
                        {
                            if (Current_value > a.Limit && !aktivni.Contains(a))
                            {
                                a.Aktivan = true;
                                //MessageBox.Show(a.Message);
                                Poruka = a.Message;
                                aktivni.Add(a);
                                
                                AlarmActivated?.Invoke(a.Id, Id, a.Message, DateTime.Now);
                            }
                            else if (Current_value <= a.Limit && aktivni.Contains(a))
                            {
                                a.Aktivan = false;
                                Poruka = "";
                                aktivni.Remove(a);
                            }
                        }
                        else // manje od limita
                        {
                            if (Current_value < a.Limit && !aktivni.Contains(a))
                            {
                                a.Aktivan = true;
                                //MessageBox.Show(a.Message);
                                Poruka = a.Message;
                                aktivni.Add(a);
                                AlarmActivated?.Invoke(a.Id, Id, a.Message, DateTime.Now);
                            }
                            else if (Current_value > a.Limit && aktivni.Contains(a))
                            {
                                a.Aktivan = false;
                                Poruka = "";
                                aktivni.Remove(a);
                            }
                        }
                    }
                }
            }
        }

        public void Stop_nit(string adress)
        {
            
            PLCInstance.tagsThreads[adress].Abort();
            PLCInstance.tagsThreads.Remove(adress);
        }

    }
}
