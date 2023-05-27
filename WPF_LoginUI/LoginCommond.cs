using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPF_LoginUI
{
    internal class LoginCommond : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null)
                {
                    CommandManager.RequerySuggested += value;
                }
            }
            remove
            {
                if (_canExecute != null)
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null) return true;
            return _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }

        /// <summary>
        /// 命令是否能够执行
        /// </summary>
        readonly Func<bool> _canExecute;
        /// <summary>
        /// 命令需要执行的方法
        /// </summary>
        readonly Action _execute;

        public LoginCommond(Action action, Func<bool> canExecute)
        {
            _execute = action;
            _canExecute = canExecute;
        }
    }
}
