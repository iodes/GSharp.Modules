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
using GSharp.Extension.Abstracts;
using GSharp.Extension.Attributes;

namespace GSharp.Modules.Control
{
    /// <summary>
    /// GPictureBox.xaml에 대한 상호 작용 논리
    /// </summary>
    [GView("사진 상자")]
    public partial class GPictureBox : GView
    {
        [GControl("내용")]
        public string Path
        {
            get
            {
                return _Path;
            }
            set
            {
                _Path = value;
                ImageContent.Source = ImageLoad(_Path);
            }
        }
        private string _Path;

        private BitmapImage ImageLoad(string path)
        {
            BitmapImage result = new BitmapImage();
            result.BeginInit();
            result.UriSource = new Uri(path);
            result.CacheOption = BitmapCacheOption.OnLoad;
            result.EndInit();

            return result;
        }

        public GPictureBox()
        {
            InitializeComponent();
        }
    }
}
