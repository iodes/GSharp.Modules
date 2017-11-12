using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;
using System;
using System.Windows.Forms;

namespace GSharp.Moudle.ConnectWeb
{
    public class ConnectWeb : GModule
    {
        [GCommand("{0} 웹 브라우저 접속")]
        public static void ConnectSite(String url)
        {
            try
            {
                System.Diagnostics.Process.Start(url);
            }
            catch
                (
                 System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show("해당 URL 혹은 브라우저를 찾을 수 없습니다.");
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }
    }
}
