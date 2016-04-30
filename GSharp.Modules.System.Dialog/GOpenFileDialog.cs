using System.Windows.Forms;
using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;

namespace GSharp.Modules.System.Dialog
{
    public class GOpenFileDialog : GModule
    {
        [GCommand("선택기로 선택된 파일")]
        public static string ShowDialog
        {
            get
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    return fileDialog.FileName;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
