using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConcentrator
{
    public enum TIP {AI,AO,DI,DO };
    public class Zajednicka : INotifyPropertyChanged
    {
        #region Field
        private string id;
        private string description;
        private string io_adress;
        private double current_value;
        private TIP tip;
        #endregion
        #region Properties
        [Key]
        public string Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged("Id");   
                }
            }
        }
        public string Description
        {
            get { return description; }
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

        public string IO_adress
        {
            get { return io_adress; }
            set
            {
                if(io_adress != value)
                {
                    io_adress = value;
                    OnPropertyChanged("IO_adress");
                }
            }
        }

        public double Current_value
        {
            get { return current_value; }
            set
            {
                if(current_value != value)
                {
                    current_value = value;
                    OnPropertyChanged("Current_value");
                }
            }
        }
        public TIP Tip
        {
            get { return tip; }
            set
            {
                if (tip != value)
                {
                    tip = value;
                    OnPropertyChanged("Tip");
                }
            }
        }

        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
