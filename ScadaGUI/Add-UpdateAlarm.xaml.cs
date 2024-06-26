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
    /// Interaction logic for Add_UpdateAlarm.xaml
    /// </summary>
    public partial class Add_UpdateAlarm : Window
    {
        public Alarms Pomocno = new Alarms();
        private bool update { get; set; }
        public Add_UpdateAlarm(Alarms novo)
        {
            InitializeComponent();
            if (novo != null) //radi se update
            {
                Pomocno.Id = novo.Id;
                Pomocno.Message = novo.Message;
                Pomocno.H_l = novo.H_l;
                Pomocno.Limit = novo.Limit;
                Pomocno.Tag_id = novo.Tag_id;
         

                update = true;
                AUAlarm.Title = "Update";
                idTxt.IsReadOnly = true;
            }
            else
            {
                update = false;
                idTxt.IsReadOnly = false;
                AUAlarm.Title = "Add";
            }
            tagIDC.ItemsSource = (from a in BaseContext.Instance.AI
                                  select a.Description).ToList();
            this.DataContext = Pomocno;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if (Validacija())
            {
                if (update)
                {
                    Alarms pom = BaseContext.Instance.Alarmi.SingleOrDefault(p => p.Id == Pomocno.Id);
                    if (pom != null) // radi se update
                    {
                        pom.Id = Pomocno.Id;
                        pom.Message = Pomocno.Message;
                        pom.H_l = Pomocno.H_l;
                        pom.Limit = Pomocno.Limit;
                        pom.Tag_id = Pomocno.Tag_id;



                        BaseContext.Instance.Entry(pom).State = System.Data.Entity.EntityState.Modified;

                    }
                }
                else
                {
                    BaseContext.Instance.Alarmi.Add(Pomocno);
                   
                }

                BaseContext.Instance.SaveChanges();

                this.Close();
            }

            else
            {
                MessageBox.Show("Nepravilan unos", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private bool Validacija()
        {
            bool validacija = true;
            //Provera imena(id)----------------------------
            if (String.IsNullOrEmpty(idTxt.Text))
            {
                validacija = false;
            }
            if (!update)
            {
                foreach (Alarms a in BaseContext.Instance.Alarmi)
                {
                    if (idTxt.Text == a.Id)
                    {
                        MessageBox.Show("Vec postoji taj alarm", "Error!", MessageBoxButton.OK);
                        return false;
                    }
                }
            }
            //provera message-----------------------------
            if (String.IsNullOrEmpty(idTxt.Text))
            {
                validacija = false;
            }

            //provera limita-----------------------------
            if (String.IsNullOrEmpty(limTxt.Text))
            {
                validacija = false;
            }
            else if (!limTxt.Text.Trim().All(char.IsDigit))
            {
                validacija = false;
            }

            return validacija;
        }
    }
}
