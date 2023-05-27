using System.ComponentModel;

namespace WPF_LoginUI
{
    public class LoginModel
    {
        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        private string _UserPassword;
        public string UserPassword
        {
            get { return _UserPassword; }
            set { _UserPassword = value; }
        }
    }
}
