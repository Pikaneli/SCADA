using DataConcentrator;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace ScadaGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static Zajednicka SelectedZajednicka { get; set; }
        public static AnalogInputs SelectedAI { get; set; }
        public static AnalogOutputs SelectedAO { get; set; }
        public static DigitalInputs SelectedDI { get; set; }
        public static DigitalOutputs SelectedDO { get; set; }
        public static Alarms SelectedAlarm { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            AnalogInputs.AlarmActivated += new AlarmActivatedHandler(OnAlarmActivated);// pretplata
            this.DataContext = this;
            VelicineGrid.ItemsSource = BaseContext.Tags;
            AlarmiGrid.ItemsSource = BaseContext.Instance.Alarmi.Local;

            load();
            BaseContext.Instance.AI.Load();
            BaseContext.Instance.AO.Load();
            BaseContext.Instance.DI.Load();
            BaseContext.Instance.DO.Load();
            BaseContext.Instance.Alarmi.Load();
            foreach (AnalogInputs a in BaseContext.Instance.AI)
            {
                a.Start_nit();
            }
            foreach (DigitalInputs a in BaseContext.Instance.DI)
            {
                a.Start_nit();
            }

        }
        public void load()
        {
            foreach (var a in BaseContext.Instance.AI)
            {
                if (!BaseContext.Tags.Contains(a))
                    BaseContext.Tags.Add(a);
            }
            foreach (var a in BaseContext.Instance.AO)
            {
                if (!BaseContext.Tags.Contains(a))
                    BaseContext.Tags.Add(a);
            }
            foreach (var a in BaseContext.Instance.DI)
            {
                if (!BaseContext.Tags.Contains(a))
                    BaseContext.Tags.Add(a);
            }
            foreach (var a in BaseContext.Instance.DO)
            {
                if (!BaseContext.Tags.Contains(a))
                    BaseContext.Tags.Add(a);
            }
        }
        #region ADD
        private void Add_DI_Click(object sender, RoutedEventArgs e)
        {
            Add_UpdateDI prozor = new Add_UpdateDI(null);
            prozor.ShowDialog();
        }

        private void Add_DO_Click(object sender, RoutedEventArgs e)
        {
            Add_UpdateDO proz = new Add_UpdateDO(null);
            proz.ShowDialog();
        }

        private void Add_AO_Click(object sender, RoutedEventArgs e)
        {
            Add_UpdateAO prozor2 = new Add_UpdateAO(null);
            prozor2.ShowDialog();
        }

        private void Add_AI_Click(object sender, RoutedEventArgs e)
        {
            Add_UpdateAI prozor1 = new Add_UpdateAI(null);
            prozor1.ShowDialog();
        }

        private void Add_Alarm_Click(object sender, RoutedEventArgs e)
        {
            Add_UpdateAlarm prozor = new Add_UpdateAlarm(null);
            prozor.ShowDialog();
        }
        #endregion
        #region DU
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedZajednicka.Tip == TIP.DI)
            {
                foreach(DigitalInputs d in BaseContext.Instance.DI)
                {
                    if (SelectedZajednicka.Id == d.Id)
                    {
                        SelectedDI = d;
                    }
                }
                Add_UpdateDI win = new Add_UpdateDI(SelectedDI);
                win.ShowDialog();
            }
            else if (SelectedZajednicka.Tip == TIP.DO)
            {
                foreach (DigitalOutputs d in BaseContext.Instance.DO)
                {
                    if (SelectedZajednicka.Id == d.Id)
                    {
                        SelectedDO = d;
                    }
                }
                Add_UpdateDO win1 = new Add_UpdateDO(SelectedDO);
                win1.ShowDialog();
            }
            else if (SelectedZajednicka.Tip == TIP.AI)
            {
                foreach (AnalogInputs a in BaseContext.Instance.AI)
                {
                    if (SelectedZajednicka.Id == a.Id)
                    {
                        SelectedAI = a;
                    }
                }
                Add_UpdateAI win2 = new Add_UpdateAI(SelectedAI);
                win2.ShowDialog();
            }
            else if (SelectedZajednicka.Tip == TIP.AO)
            {
                foreach (AnalogOutputs a in BaseContext.Instance.AO)
                {
                    if (SelectedZajednicka.Id == a.Id)
                    {
                        SelectedAO = a;   
                    }
                }
                Add_UpdateAO win3 = new Add_UpdateAO(SelectedAO);
                win3.ShowDialog();
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Da li ste sigurni?", "Brisanje tagova", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                if (SelectedZajednicka.Tip == TIP.DI)
                {
                    foreach (DigitalInputs d in BaseContext.Instance.DI)
                    {
                        if (SelectedZajednicka.Id == d.Id)
                        {
                            SelectedDI = d;
                        }
                    }
                    BaseContext.Instance.DI.Remove(SelectedDI);
                    BaseContext.Tags.Remove(SelectedZajednicka);
                    BaseContext.Instance.SaveChanges();
                    SelectedDI.Stop_nit(SelectedDI.IO_adress);
                }
                else if (SelectedZajednicka.Tip == TIP.DO)
                {
                    foreach (DigitalOutputs d in BaseContext.Instance.DO)
                    {
                        if (SelectedZajednicka.Id == d.Id)
                        {
                            SelectedDO = d;
                        }
                    }
                    BaseContext.Instance.DO.Remove(SelectedDO);
                    BaseContext.Tags.Remove(SelectedZajednicka);
                    BaseContext.Instance.SaveChanges();
                }
                else if (SelectedZajednicka.Tip == TIP.AI)
                {
                    foreach (AnalogInputs a in BaseContext.Instance.AI)
                    {
                        if (SelectedZajednicka.Id == a.Id)
                        {
                            SelectedAI = a;
                        }
                    }
                    BaseContext.Instance.AI.Remove(SelectedAI);
                    BaseContext.Tags.Remove(SelectedZajednicka);
                    BaseContext.Instance.SaveChanges();
                }
                else if (SelectedZajednicka.Tip == TIP.AO)
                {
                    foreach (AnalogOutputs a in BaseContext.Instance.AO)
                    {
                        if (SelectedZajednicka.Id == a.Id)
                        {
                            SelectedAO = a;
                        }
                    }
                    BaseContext.Instance.AO.Remove(SelectedAO);
                    BaseContext.Tags.Remove(SelectedZajednicka);
                    BaseContext.Instance.SaveChanges();
                }
            }
        }
        #endregion
        private void DeleteAlarm_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Da li ste sigurni?", "Brisanje alarma", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
            if (result == MessageBoxResult.Yes)
            {
                BaseContext.Instance.Alarmi.Remove(SelectedAlarm);
                BaseContext.Instance.SaveChanges();
            }
        }
        private void UpdateAlarm_Click(object sender, RoutedEventArgs e)
        {
            Add_UpdateAlarm prozor = new Add_UpdateAlarm(SelectedAlarm);
            prozor.ShowDialog();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            BaseContext.Instance.Dispose();
        }
        public static void OnAlarmActivated(string id, string tagName, string message, DateTime t)
        {
            using (StreamWriter notepad = File.AppendText(@"..\..\nesto.txt"))
            {
                string a = "Alarm ID: " + id + " ,Tag name: " + tagName + " ,Alarm message: " + message + " , Date and time: " + t;
                notepad.WriteLine(a);
            }

        }
    }
    
}
