using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConcentrator
{
    public class Alarms : INotifyPropertyChanged
    {
        private string id;
        private string message;
        private bool h_l;
        private double limit;
        private string tag_id;
        private bool aktivan;


        [Key]
        #region Properties
        public string Id
        {
            get { return id; }
            set
            {
                if(id != value)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public string Message
        {
            get { return message; }
            set
            {
                if (message != value)
                {
                    message = value;
                    OnPropertyChanged("Message");
                }
            }
        }

        public bool Aktivan
        {
            get { return aktivan; }
            set
            {
                if (aktivan != value)
                {
                    aktivan = value;
                    OnPropertyChanged("Aktivan");
                }
            }
        }

        public bool H_l
        {
            get { return h_l; }
            set
            {
                if (h_l != value)
                {
                    h_l = value;
                    OnPropertyChanged("H_l");
                }
            }
        }

        public double Limit
        {
            get { return limit; }
            set
            {
                if (limit != value)
                {
                    limit = value;
                    OnPropertyChanged("Limit");
                }
            }
        }


        public string Tag_id
        {
            get { return tag_id; }
            set
            {
                if (tag_id != value)
                {
                    tag_id = value;
                    OnPropertyChanged("Tag_id");
                }
            }
        }
#endregion
        [ForeignKey("Tag_id")]
        public virtual AnalogInputs AI { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
