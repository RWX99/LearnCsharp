using System.Windows;

namespace WPF_LoginUI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            DataContext = new LoginViewModel(this);
        }
    }
}
