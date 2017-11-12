using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;
using System;
using System.Diagnostics;

namespace GSharp.Moudles.Cpu
{
    public class UsingCpu : GModule
    {
        [GCommand("CPU 이용률")]
        public static String GetUsingCpu()
        {
            PerformanceCounter Cpu = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            float CpuUse = Cpu.NextValue();
            string cpuReturn = Convert.ToString((int)CpuUse) + "%";

            return cpuReturn;
        }
    }
}

