﻿using DataConcentrator;
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
    /// Interaction logic for Add_UpdateDI.xaml
    /// </summary>
    public partial class Add_UpdateDI : Window
    {
        public DigitalInputs Pomocno = new DigitalInputs { Tip = TIP.DI };
        
        private bool update { get; set; }
        public Add_UpdateDI(DigitalInputs novo)
        {
            InitializeComponent();
            if (novo != null)
            {
                Pomocno.Id = novo.Id;
                Pomocno.IO_adress = novo.IO_adress;
                Pomocno.Scan_time = novo.Scan_time;
                Pomocno.On_off_scan = novo.On_off_scan;
                Pomocno.Current_value = novo.Current_value;
                Pomocno.Description = novo.Description;


                update = true;
                Doo.Title = "Osvezi";
                idTxt.IsReadOnly = true;

                this.adresCombo.ItemsSource = new List<string> { "ADDR009", "ADDR010", "ADDR011", "ADDR012" };
                adresCombo.SelectedItem = Pomocno.IO_adress;
                adresCombo.IsEnabled = false;
            }
            else
            {
                update = false;
                idTxt.IsReadOnly = false;
                Doo.Title = "Dodaj";
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
                    DigitalInputs pom = BaseContext.Instance.DI.SingleOrDefault(p => p.Id == Pomocno.Id);
                    if (pom != null) // radi se update
                    {
                        pom.Id = Pomocno.Id;
                        pom.IO_adress = Pomocno.IO_adress;
                        pom.Description = Pomocno.Description;
                        pom.Current_value = Pomocno.Current_value;
                        pom.Scan_time = Pomocno.Scan_time;
                        pom.On_off_scan = Pomocno.On_off_scan;





                        BaseContext.Instance.Entry(pom).State = System.Data.Entity.EntityState.Modified;

                    }
                }
                else
                {
                    BaseContext.Instance.DI.Add(Pomocno);
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
                foreach (DigitalInputs a in BaseContext.Instance.DI)
                {
                    if (idTxt.Text == a.Id)
                    {
                        MessageBox.Show("Vec postoji taj digitalni ulaz", "Error!", MessageBoxButton.OK);
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
            //provera scan time
            if (String.IsNullOrEmpty(stTxt.Text))
            {
                validacija = false;
            }
            else if (!stTxt.Text.Trim().All(char.IsDigit))
            {
                validacija = false;
            }


            return validacija;
        }

        private List<string> Adrese()
        {
            List<string> pomocnaL = new List<string> { "ADDR009", "ADDR010", "ADDR011", "ADDR012" };
            foreach (DigitalInputs d in BaseContext.Instance.DI)
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