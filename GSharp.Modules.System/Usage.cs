using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;
using System;
using System.Diagnostics;

namespace GSharp.Modules.System
{
    public class Usage : GModule
    {
        [GCommand("CPU 이용률")]
        public static string GetUsingCpu()
        {
            var Cpu = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            var CpuUse = Cpu.NextValue();
            var cpuReturn = Convert.ToString((int)CpuUse) + "%";

            return cpuReturn;
        }

        [GCommand("RAM 이용률")]
        public static string GetUsingRam()
        {
            var Ram = new PerformanceCounter("Memory", "Available MBytes");
            var RamUse = Ram.NextValue();
            var ramReturn = Convert.ToString(RamUse) + "MB";

            return ramReturn;
        }
    }
}
