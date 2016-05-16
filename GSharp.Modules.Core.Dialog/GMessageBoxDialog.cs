using System.Windows.Forms;
using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;

namespace GSharp.Modules.Core.Dialog
{
    public class GMessageBoxDialog : GModule
    {
        [GCommand("오류 메시지 상자에 {0} 출력")]
        public static void ShowDialogError(string value)
        {
            MessageBox.Show(value, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        [GCommand("경고 메시지 상자에 {0} 출력")]
        public static void ShowDialogExclamation(string value)
        {
            MessageBox.Show(value, "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        [GCommand("정보 메시지 상자에 {0} 출력")]
        public static void ShowDialogInformation(string value)
        {
            MessageBox.Show(value, "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
