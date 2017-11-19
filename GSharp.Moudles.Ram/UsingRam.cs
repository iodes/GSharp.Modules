using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;
using System;
using System.Diagnostics;

namespace GSharp.Moudles.Ram
{
    public class UsingRam : GModule
    {
        [GCommand("CPU 이용률")]
        public static string GetUsingRam()
        {
            PerformanceCounter Ram = new PerformanceCounter("Memory", "Available MBytes");
            float RamUse = Ram.NextValue();
            string ramReturn = Convert.ToString(RamUse) + "MB";

            return ramReturn;
        }
    }
}
