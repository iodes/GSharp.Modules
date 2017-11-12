using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;

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
