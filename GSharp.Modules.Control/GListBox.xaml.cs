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
    /// GListBox.xaml에 대한 상호 작용 논리
    /// </summary>
    [GView("목록 상자")]
    public partial class GListBox : GView
    {
        [GControl("내용")]
        public List<object> Items
        {
            get
            {
                return _Items;
            }
            set
            {
                _Items = value;
                ListBoxContent.ItemsSource = _Items;
            }
        }
        private List<object> _Items;

        [GControl("선택된 내용")]
        public string SelectedItem
        {
            get
            {
                return ListBoxContent.SelectedItem.ToString();
            }
        }

        [GControl("선택 변경")]
        public event SelectChangedEventHandler SelectChanged;
        public delegate void SelectChangedEventHandler();

        public GListBox()
        {
            InitializeComponent();
        }

        private void ListBoxContent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectChanged?.Invoke();
        }
    }
}
