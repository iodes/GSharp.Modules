using GSharp.Extension.Attributes;

namespace GSharp.Modules.Registry
{
    public class RegDelete
    {
        [GCommand("{0}레지스트리 하위키 제거")]
        public static void RegRemove(string RegPath)
        {
            Microsoft.Win32.Registry.LocalMachine.DeleteSubKey(RegPath, false);
        }
    }
}
