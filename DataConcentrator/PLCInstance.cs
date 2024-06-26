using PLCSimulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataConcentrator
{
    public class PLCInstance
    {
        public static PLCSimulatorManager instance;
        public static Dictionary<string, Thread> tagsThreads = new Dictionary<string, Thread>(); 
        public static PLCSimulatorManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PLCSimulatorManager();
                    instance.StartPLCSimulator();
                }
                return instance;
            }
        }
    }

}
