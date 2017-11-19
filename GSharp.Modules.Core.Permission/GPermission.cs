using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;
using System.Windows;

namespace GSharp.Modules.Core.Permission
{
    public class GPermission : GModule
    {
        #region 상수
        public const int _errorCancelled = 1223;
        #endregion

        #region 속성
        [GCommand("관리자 권한 상태")]
        public static bool IsAdmin
        {
            get
            {
                using (var identity = WindowsIdentity.GetCurrent())
                {
                    var principal = new WindowsPrincipal(identity);
                    return principal.IsInRole(WindowsBuiltInRole.Administrator);
                }
            }
        }
        #endregion

        #region 사용자 함수
        [GCommand("관리자 권한 요청")]
        public static void RequestAdministrator()
        {
            var info = new ProcessStartInfo(Assembly.GetEntryAssembly().Location)
            {
                Verb = "runas",
                UseShellExecute = true
            };

            try
            {
                Process.Start(info);
                Process.GetCurrentProcess().Kill();
            }
            catch (Win32Exception ex)
            {
                if (ex.NativeErrorCode == _errorCancelled)
                {
                    MessageBox.Show("관리자 권한 요청이 거부되었습니다.", "오류", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        #endregion
    }
}
