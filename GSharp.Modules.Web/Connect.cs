using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;

namespace GSharp.Modules.Web
{
    public class Connect : GModule
    {
        [GCommand("{0} 웹 브라우저 접속")]
        public static void ConnectWeb(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch (Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                {
                    MessageBox.Show("해당 URL 혹은 브라우저를 찾을 수 없습니다.");
                }
            }
            catch (Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }
    }
}
