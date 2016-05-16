using System.Windows.Forms;
using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;

namespace GSharp.Modules.Core.Dialog
{
    public class GSaveFileDialog : GModule
    {
        [GCommand("저장 선택기로 선택한 파일")]
        public static string ShowDialog
        {
            get
            {
                SaveFileDialog fileDialog = new SaveFileDialog();
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
