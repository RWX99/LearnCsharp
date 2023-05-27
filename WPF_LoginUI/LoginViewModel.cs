using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPF_LoginUI
{
    internal class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private LoginModel _loginModel = new LoginModel();

        public string UserName
        {
            get { return _loginModel.UserName; }
            set { _loginModel.UserName = value; NotifyPropertyChanged("UserName"); }
        }

        public string UserPassword
        {
            get { return _loginModel.UserPassword; }
            set { _loginModel.UserPassword = value; NotifyPropertyChanged("UserPassword"); }
        }

        private MainWindow _main;
        public LoginViewModel(MainWindow main)
        {
            _main = main;
        }

        void LoginFunc()
        {
            //_main.btn.Focus();
            if (string.Equals(UserName, "wpf") && string.Equals(UserPassword, "666"))
            {
                new Index().Show();
                _main.Close();
            }
            else
            {
                MessageBox.Show("输入的用户名或密码不正确");
                UserName = string.Empty;
                UserPassword = string.Empty;
            }
        }

        bool CanLoginExecute() => true;

        public ICommand LoginAction
        {
            get
            {
                return new LoginCommond(LoginFunc, CanLoginExecute);
            }
        }
    }
}
