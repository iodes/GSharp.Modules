using System.Windows;
using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;

namespace GSharp.Modules.Core.Console
{
    public class GConsole : GModule
    {
        #region 객체
        private static GConsoleUI consoleUI;
        private static Window consoleWindow;
        #endregion

        #region 속성
        [GCommand("콘솔에 입력된 문자")]
        public static string ReceivedText { get; set; }
        #endregion

        #region 이벤트
        [GCommand("콘솔에 입력된 경우")]
        public static event ReceivedEventHandler Received;
        public delegate void ReceivedEventHandler();
        #endregion

        #region 사용자 함수
        [GCommand("콘솔 창 열기")]
        public static void Show()
        {
            consoleUI = new GConsoleUI();
            consoleUI.Received += () =>
            {
                ReceivedText = consoleUI.ReceivedText;
                Received?.Invoke();
            };

            consoleWindow = new Window
            {
                Width = 500,
                Height = 500,
                Title = "입출력 콘솔",
                Content = consoleUI,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
            };

            consoleWindow.Show();
        }

        [GCommand("콘솔 창 닫기")]
        public static void Close()
        {
            consoleWindow?.Close();
        }

        [GCommand("콘솔에 {0} 출력")]
        public static void Write(string value)
        {
            consoleUI.Write(value);
        }
        #endregion
    }
}
