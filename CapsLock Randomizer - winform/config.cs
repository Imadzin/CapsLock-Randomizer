using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CapsLock_Randomizer___winform
{
    internal class config
    {

        public static int interval;
        public static int MinInterval;
        public static int MaxInterval;

        public static bool VariableIntervalEnabled;


        public static void DefaultConfig()
        {
            ConfigWrite("10",false); //def
            ConfigWrite("5", true); //min
            ConfigWrite("15", true); //max
            ConfigWrite("False", true);


            ConfigLoad();
        }

        public static void ConfigTest()
        {
            if (!File.Exists("Config.txt"))
            {
                DefaultConfig();
            }
        }

        public static void ConfigWrite(string txt, bool append)
        {
            using (StreamWriter sw = new StreamWriter("Config.txt", append))
            {
                sw.WriteLine(txt);
                sw.Flush();
            }
        }


        public static string ConfigRead(int line)
        {
            return File.ReadAllLines("Config.txt").Skip(line).Take(1).First();
        }


        public static void ConfigLoad()
        {
            interval=Convert.ToInt32(ConfigRead(0));
            MinInterval=Convert.ToInt32(ConfigRead(1));
            MaxInterval=Convert.ToInt32(ConfigRead(2));
            VariableIntervalEnabled=Convert.ToBoolean(ConfigRead(3));
        }


        public static void ConfigRefresh()
        {
            ConfigWrite(interval.ToString(), false); 
            ConfigWrite(MinInterval.ToString(), true); 
            ConfigWrite(MaxInterval.ToString(), true); 
            ConfigWrite(VariableIntervalEnabled.ToString(), true);
        }

    }
}

