using DataConcentrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ScadaGUI
{
    /// <summary>
    /// Interaction logic for Add_UpdateAI.xaml
    /// </summary>
    public partial class Add_UpdateAI : Window
    {
        public AnalogInputs Pomocno = new AnalogInputs { Tip = TIP.AI };
        private bool update { get; set; }
        public Add_UpdateAI(AnalogInputs novo)
        {
            InitializeComponent();
            if (novo != null)
            {
                Pomocno.Id = novo.Id;
                Pomocno.IO_adress= novo.IO_adress;
                Pomocno.High_limit = novo.High_limit;
                Pomocno.Low_limit = novo.Low_limit;
                Pomocno.Scan_time = novo.Scan_time;
                Pomocno.On_off_scan = novo.On_off_scan;
                Pomocno.Units = novo.Units;
                Pomocno.Current_value = novo.Current_value;
                Pomocno.Description= novo.Description;


                update = true;
                Add_Update.Title = "Update";
                idTxt.IsReadOnly = true;

                this.adresCombo.ItemsSource = new List<string> { "ADDR001", "ADDR002", "ADDR003", "ADDR004" };
                adresCombo.SelectedItem = Pomocno.IO_adress;
                adresCombo.IsEnabled = false;
            }
            else
            {
                update = false;
                idTxt.IsReadOnly = false;
                Add_Update.Title = "Add";
                adresCombo.ItemsSource = Adrese();
                adresCombo.IsEnabled = true;
            }

            this.DataContext = Pomocno;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if (Validacija())
            {
                if (update)
                {
                    AnalogInputs pom = BaseContext.Instance.AI.SingleOrDefault(p => p.Id == Pomocno.Id);
                    if (pom != null) // radi se update
                    {
                        pom.Id = Pomocno.Id;
                        pom.IO_adress = Pomocno.IO_adress;
                        pom.Low_limit = Pomocno.Low_limit;
                        pom.On_off_scan = Pomocno.On_off_scan;
                        pom.Units= Pomocno.Units;
                        pom.Scan_time= Pomocno.Scan_time;
                        pom.Description= Pomocno.Description;
                        pom.Current_value= Pomocno.Current_value;
                        pom.High_limit= Pomocno.High_limit;



                        BaseContext.Instance.Entry(pom).State = System.Data.Entity.EntityState.Modified;

                    }
                }
                else
                {
                    BaseContext.Instance.AI.Add(Pomocno);
                    BaseContext.Tags.Add(Pomocno);
                    Pomocno.Start_nit();
                }

                BaseContext.Instance.SaveChanges();
                
                this.Close();
            }

            else
            {
                MessageBox.Show("Nepravilan unos", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool Validacija()
        {
            bool validacija = true;
            //provera id
            if (String.IsNullOrEmpty(idTxt.Text))
            {
                validacija = false;
            }
            if (!update)
            {
                foreach (AnalogInputs a in BaseContext.Instance.AI)
                {
                    if (idTxt.Text == a.Id)
                    {
                        MessageBox.Show("Vec postoji taj analogni ulaz", "Error!", MessageBoxButton.OK);
                        return false;
                    }
                }
            }
            //provera description
            if (String.IsNullOrEmpty(desTxt.Text))
            {
                validacija = false;
            }
            //provera adrese
            if (adresCombo.SelectedIndex == -1)
            {
               validacija = false;
            }

            //provera high limit
            if (String.IsNullOrEmpty(hlTxt.Text))
            {
                validacija = false;
            }
            else if (!hlTxt.Text.Trim().All(char.IsDigit))
            {
                validacija = false;
            }

            //provera low limit
            if (String.IsNullOrEmpty(llTxt.Text))
            {
                validacija = false;
            }
            else if (!llTxt.Text.Trim().All(char.IsDigit))
            {
                validacija = false;
            }

            //provera scan time
            if (String.IsNullOrEmpty(stTxt.Text))
            {
                validacija = false;
            }
            else if (!stTxt.Text.Trim().All(char.IsDigit))
            {
                validacija = false;
            }

            //provera units
            if (String.IsNullOrEmpty(stTxt.Text))
            {
                validacija = false;
            }
            //else if (!stTxt.Text.Trim().All(char.IsLetter))
            //{
            //    validacija = false;
            //}

            return validacija;
        }

        private List<string> Adrese()
        {
            List<string> pomocnaL = new List<string> { "ADDR001", "ADDR002", "ADDR003", "ADDR004" };
            foreach (AnalogInputs d in BaseContext.Instance.AI)
            {

                if (pomocnaL.Contains(d.IO_adress))
                {
                    pomocnaL.Remove(d.IO_adress);
                }
            }
            return pomocnaL;
        }
    }
}
