using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConcentrator
{
    public class BaseContext : DbContext
    {
        private static BaseContext instance;
        public DbSet<DigitalInputs> DI { get; set; }
        public DbSet<AnalogInputs> AI { get; set; }
        public DbSet<DigitalOutputs> DO { get; set; }
        public DbSet<AnalogOutputs> AO { get; set; }
        public static ObservableCollection<Zajednicka> Tags = new ObservableCollection<Zajednicka>();
        public DbSet<Alarms> Alarmi { get; set; }
        private BaseContext() { }
        public static BaseContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BaseContext();
                }
                return instance;
            }
        }
    }
}
