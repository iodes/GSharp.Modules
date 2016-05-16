using System.Drawing;
using System.Windows.Forms;
using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;

namespace GSharp.Modules.Core.Dialog
{
    public class GColorDialog : GModule
    {
        [GCommand("선택기로 선택한 색상")]
        public static string ShowDialog
        {
            get
            {
                ColorDialog colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    return ColorTranslator.ToHtml(colorDialog.Color);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
