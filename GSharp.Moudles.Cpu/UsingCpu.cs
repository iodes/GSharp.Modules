using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;

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

