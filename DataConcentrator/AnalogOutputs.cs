using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConcentrator
{
   public class AnalogOutputs : Zajednicka
    {
        private double initial_value;
        private double low_limit;
        private double high_limit;
        private string units;

        public double Initial_value
        {
            get { return initial_value; }
            set
            {
                if (initial_value != value)
                {
                    initial_value = value;
                    OnPropertyChanged("Initial_value");
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


    }
}
