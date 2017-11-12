using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSharp.Moudles.Ram
{
    public class UsingRam : GModule
    {
        [GCommand("CPU 이용률")]
        public static String GetUsingRam()
        {
            PerformanceCounter Ram = new PerformanceCounter("Memory", "Available MBytes");
            float RamUse = Ram.NextValue();
            string ramReturn = Convert.ToString(RamUse) + "MB";

            return ramReturn;
        }
    }
}
