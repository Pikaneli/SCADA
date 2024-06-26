using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataConcentrator
{
   public class DigitalInputs : Zajednicka
    {
        private int scan_time;
        private bool on_off_scan;
        private object locker = new object();
        #region Properties
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
        #endregion

        public void Start_nit()
        {
            Thread t = new Thread(() => scan());
            PLCInstance.tagsThreads.Add(IO_adress,t);
            t.Start();
        }

        private void scan()
        {
            while (true)
            {
                lock (locker)
                {
                    if (On_off_scan)
                    {
                        Current_value = PLCInstance.Instance.GetDigitalValue(IO_adress);
                    }
                }
                Thread.Sleep(Scan_time);
            }
        }

        public void Stop_nit(string address)
        {
            PLCInstance.tagsThreads[address].Abort();
            PLCInstance.tagsThreads.Remove(address);
        }
    }
}
