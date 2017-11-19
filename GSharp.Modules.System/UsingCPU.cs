using GSharp.Extension.Attributes;
using System;
using System.Diagnostics;

namespace GSharp.Modules.System
{
    public class UsingCPU
    {
        [GCommand("CPU 이용률")]
        public static string GetUsingCpu()
        {
            var Cpu = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            var CpuUse = Cpu.NextValue();
            var cpuReturn = Convert.ToString((int)CpuUse) + "%";

            return cpuReturn;
        }
    }
}
