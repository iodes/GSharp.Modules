using System.Windows.Forms;
using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;

namespace GSharp.Modules.Core.Dialog
{
    public class GFontDialog : GModule
    {
        [GCommand("선택기로 선택한 서체")]
        public static string ShowDialog
        {
            get
            {
                FontDialog fontDialog = new FontDialog();
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    return fontDialog.Font.Name;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
