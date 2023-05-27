using System;
using System.Windows;
using System.Windows.Controls;

namespace WPF_LoginUI
{
    internal class PasswordBoxHelper
    {
        public static readonly DependencyProperty MyPasswordProperty = DependencyProperty.RegisterAttached("MyPassword", typeof(string), typeof(PasswordBoxHelper), new PropertyMetadata(string.Empty, OnPwdPropertyChanged));

        public static string GetMyPassword(DependencyObject obj) => (string)obj.GetValue(MyPasswordProperty);

        public static void SetMyPassword(DependencyObject obj, string value) => obj.SetValue(MyPasswordProperty, value);

        private static void OnPwdPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox pwd = d as PasswordBox;
            if (pwd == null) return;
            pwd.Password = (string)e.NewValue;
        }

        public static readonly DependencyProperty IsEnableBindProperty = DependencyProperty.RegisterAttached("IsEnableBind", typeof(bool), typeof(PasswordBoxHelper), new PropertyMetadata(false, OnPasswordPropertyChanged));

        public static bool GetIsEnableBind(DependencyObject obj) => (bool)obj.GetValue(IsEnableBindProperty);

        public static void SetIsEnableBind(DependencyObject obj, bool value) => obj.SetValue(IsEnableBindProperty, value);

        private static void OnPasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox pwd = d as PasswordBox;
            if (pwd == null) return;
            if ((bool)e.NewValue) pwd.PasswordChanged += OnPwdProChanged;
            else if ((bool)e.OldValue) pwd.PasswordChanged -= OnPwdProChanged;
        }

        private static void OnPwdProChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox pwd = (PasswordBox)sender;
            SetMyPassword(pwd, pwd.Password);
        }
    }
}
