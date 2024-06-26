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
    /// Interaction logic for Add_UpdateAO.xaml
    /// </summary>
    public partial class Add_UpdateAO : Window
    {
        public AnalogOutputs Pomocno = new AnalogOutputs { Tip = TIP.AO };
        private bool update { get; set; }
        public Add_UpdateAO(AnalogOutputs novo)
        {
            InitializeComponent();
            if (novo != null)
            {
                Pomocno.Id = novo.Id;
                Pomocno.IO_adress = novo.IO_adress;
                Pomocno.High_limit = novo.High_limit;
                Pomocno.Low_limit = novo.Low_limit;
                Pomocno.Initial_value = novo.Initial_value;
                Pomocno.Units = novo.Units;
                Pomocno.Current_value = novo.Current_value;
                Pomocno.Description = novo.Description;


                update = true;
                Add_Updateao.Title = "Osvezi";
                idTxt.IsReadOnly = true;
                this.adresCombo.ItemsSource = new List<string> { "ADDR005", "ADDR006", "ADDR007", "ADDR008" };
                adresCombo.SelectedItem = Pomocno.IO_adress;
                adresCombo.IsEnabled = false;
            }
            else
            {
                update = false;
                idTxt.IsReadOnly = false;
                Add_Updateao.Title = "Dodaj";
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
                    AnalogOutputs pom = BaseContext.Instance.AO.SingleOrDefault(p => p.Id == Pomocno.Id);
                    if (pom != null) // radi se update
                    {
                        Pomocno.Current_value = Pomocno.Initial_value;
                        pom.Id = Pomocno.Id;
                        pom.IO_adress = Pomocno.IO_adress;
                        pom.Low_limit = Pomocno.Low_limit;
                        pom.Units = Pomocno.Units;
                        pom.Description = Pomocno.Description;
                        pom.Current_value = Pomocno.Current_value;
                        pom.High_limit = Pomocno.High_limit;
                        pom.Initial_value = Pomocno.Initial_value;

                        

                        BaseContext.Instance.Entry(pom).State = System.Data.Entity.EntityState.Modified;
                        PLCInstance.Instance.SetAnalogValue(Pomocno.IO_adress, Pomocno.Initial_value);

                    }
                }
                else
                {
                    Pomocno.Current_value = Pomocno.Initial_value;
                    BaseContext.Instance.AO.Add(Pomocno);
                    BaseContext.Tags.Add(Pomocno);
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
                foreach (AnalogOutputs a in BaseContext.Instance.AO)
                {
                    if (idTxt.Text == a.Id)
                    {
                        MessageBox.Show("Vec postoji taj analogni izlaz", "Error!", MessageBoxButton.OK);
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

            //provera initial value
            if (String.IsNullOrEmpty(ivTxt.Text))
            {
                validacija = false;
            }
            else if (!ivTxt.Text.Trim().All(char.IsDigit))
            {
                validacija = false;
            }
            //provera units
            if (String.IsNullOrEmpty(uTxt.Text))
            {
                validacija = false;
            }
           // else if (!uTxt.Text.Trim().All(char.IsLetter))
            //{
            //    validacija = false;
            //}


            return validacija;
        }

        private List<string> Adrese()
        {
            List<string> pomocnaL = new List<string> { "ADDR005", "ADDR006", "ADDR007", "ADDR008" };
            foreach (AnalogOutputs d in BaseContext.Instance.AO)
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
