using System.Windows.Forms;
using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;

namespace GSharp.Modules.System.Dialog
{
    public class GFolderBrowserDialog : GModule
    {
        [GCommand("선택기로 선택된 폴더")]
        public static string ShowDialog
        {
            get
            {
                FolderBrowserDialog folderDialog = new FolderBrowserDialog();
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    return folderDialog.SelectedPath;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
