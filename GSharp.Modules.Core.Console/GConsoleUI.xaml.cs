using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GSharp.Modules.Core.Console
{
    /// <summary>
    /// GConsoleUI.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class GConsoleUI : UserControl
    {
        #region 객체
        private ScrollViewer currentScrollViewer;
        #endregion

        #region 속성
        public string ReceivedText { get; set; }
        #endregion

        #region 이벤트
        public event ReceivedEventHandler Received;
        public delegate void ReceivedEventHandler(string value);
        #endregion

        #region 생성자
        public GConsoleUI()
        {
            InitializeComponent();
        }
        #endregion

        #region 사용자 함수
        public void Write(string value)
        {
            listConsole.Items.Add(value);

            if (VisualTreeHelper.GetChildrenCount(listConsole) > 0)
            {
                if (currentScrollViewer == null)
                {
                    Border border = (Border)VisualTreeHelper.GetChild(listConsole, 0);
                    currentScrollViewer = (ScrollViewer)VisualTreeHelper.GetChild(border, 0);
                }

                currentScrollViewer?.ScrollToBottom();
            }
        }
        #endregion

        #region 텍스트 입력 이벤트
        private void textInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ReceivedText = textInput.Text;

                TextBlock inputBlock = new TextBlock
                {
                    Text = ReceivedText,
                    Foreground = Brushes.Green
                };

                listConsole.Items.Add(inputBlock);
                textInput.Clear();

                Received?.Invoke(ReceivedText);
            }
        }
        #endregion
    }
}
