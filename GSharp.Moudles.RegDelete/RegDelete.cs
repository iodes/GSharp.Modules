using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSharp.Moudles.RegDelete
{
    public class RegDelete : GModule
    {
        [GCommand("{0}레지스트리 하위키 제거")]
        public static void RegRemove(string RegPath)
        {
            Microsoft.Win32.Registry.LocalMachine.DeleteSubKey(RegPath, false);
        }
    }
}
