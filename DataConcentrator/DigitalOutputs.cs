using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConcentrator
{
   public class DigitalOutputs : Zajednicka
    {
        private double initial_value;

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

    }
}
