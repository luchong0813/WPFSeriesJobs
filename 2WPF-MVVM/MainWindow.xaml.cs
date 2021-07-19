using _2WPF_MVVM.ViewModel;
using GalaSoft.MvvmLight.Messaging;
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

namespace _2WPF_MVVM
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var vm = new MainViewModel();
            DataContext = new MainViewModel();

            Messenger.Default.Register<string>(this, "ExecuteMenuItem", ShowMenuBtnClick);
        }

        private void ShowMenuBtnClick(string content)
        {
            MessageBox.Show(content);
        }
    }
}
