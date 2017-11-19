using GSharp.Extension.Attributes;
using System;
using System.Diagnostics;

namespace GSharp.Modules.System
{
    public class UsingRAM
    {
        [GCommand("CPU 이용률")]
        public static string GetUsingRam()
        {
            var Ram = new PerformanceCounter("Memory", "Available MBytes");
            var RamUse = Ram.NextValue();
            var ramReturn = Convert.ToString(RamUse) + "MB";

            return ramReturn;
        }
    }
}
