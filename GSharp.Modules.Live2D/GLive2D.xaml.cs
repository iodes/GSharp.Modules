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
using L2DLib.Framework;
using L2DLib.Utility;

namespace GSharp.Modules.Live2D
{
    /// <summary>
    /// GLive2D.xaml에 대한 상호 작용 논리
    /// </summary>
    [GView("캐릭터 상자")]
    public partial class GLive2D : GView
    {
        [GControl("모델")]
        public string Path
        {
            get
            {
                return _Path;
            }
            set
            {
                _Path = value;

                _Model?.Dispose();
                _Model = L2DFunctions.LoadModel(_Path);
                _Model.UseBreath = true;
                _Model.UseEyeBlink = true;

                ContentView.Model = _Model;
            }
        }
        private string _Path;
        private L2DModel _Model;

        public GLive2D()
        {
            InitializeComponent();
        }
    }
}
