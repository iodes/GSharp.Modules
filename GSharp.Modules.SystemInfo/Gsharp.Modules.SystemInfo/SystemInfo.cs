using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Gsharp.Modules.SystemInfo
{
    public class SystemInfo : GModule
    {
       

        [GCommand("현재 CPU 사용량")]
        public static int CPU_Used
        {
            get
            {
                PerformanceCounter cpu = new PerformanceCounter("Processor", "% Processor Time", "_Total");
                return (int)cpu.NextValue();
            }
        }
    }
}
