using System.Windows.Forms;
using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;

namespace GSharp.Modules.Core.Dialog
{
    public class GMessageBoxDialog : GModule
    {
        [GCommand("메시지 상자에 {0} 출력")]
        public static void ShowDialog(string value)
        {
            MessageBox.Show(value);
        }
    }
}
