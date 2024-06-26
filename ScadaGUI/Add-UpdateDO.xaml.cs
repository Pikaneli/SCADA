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
    /// Interaction logic for Add_UpdateDO.xaml
    /// </summary>
    public partial class Add_UpdateDO : Window
    {

        public DigitalOutputs Pomocno = new DigitalOutputs { Tip = TIP.DO };
        private bool update { get; set; }
        public Add_UpdateDO(DigitalOutputs novo)
        {
            InitializeComponent();
            if (novo != null)
            {
                Pomocno.Id = novo.Id;
                Pomocno.IO_adress = novo.IO_adress;
                Pomocno.Initial_value = novo.Initial_value;
                Pomocno.Current_value = novo.Current_value;
                Pomocno.Description = novo.Description;


                update = true;
                doo.Title = "Update";
                idTxt.IsReadOnly = true;

                this.adresCombo.ItemsSource = new List<string> { "ADDR014", "ADDR015", "ADDR016", "ADDR017" };
                adresCombo.SelectedItem = Pomocno.IO_adress;
                adresCombo.IsEnabled = false;
            }
            else
            {
                update = false;
                idTxt.IsReadOnly = false;
                doo.Title = "Add";
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
                    DigitalOutputs pom = BaseContext.Instance.DO.SingleOrDefault(p => p.Id == Pomocno.Id);
                    if (pom != null) // radi se update
                    {
                        Pomocno.Current_value = Pomocno.Initial_value;
                        pom.Id = Pomocno.Id;
                        pom.IO_adress = Pomocno.IO_adress;
                        pom.Description = Pomocno.Description;
                        pom.Current_value = Pomocno.Current_value;
                        pom.Initial_value = Pomocno.Initial_value;

                        BaseContext.Instance.Entry(pom).State = System.Data.Entity.EntityState.Modified;
                        PLCInstance.Instance.SetDigitalValue(Pomocno.IO_adress,Pomocno.Initial_value);
                    }
                }
                else
                {
                    BaseContext.Instance.DO.Add(Pomocno);
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
                foreach (DigitalOutputs a in BaseContext.Instance.DO)
                {
                    if (idTxt.Text == a.Id)
                    {
                        MessageBox.Show("Vec postoji taj digitalni izlaz", "Error!", MessageBoxButton.OK);
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
            //provera initial value
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
            List<string> pomocnaL = new List<string> { "ADDR014", "ADDR015", "ADDR016", "ADDR017" };
            foreach (DigitalOutputs d in BaseContext.Instance.DO)
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