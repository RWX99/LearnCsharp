using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPF_LoginUI
{
    internal class CustomButton : Button
    {
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(CustomButton));

        public CornerRadius CornerRadius
        {
            get
            {
                return (CornerRadius)GetValue(CornerRadiusProperty);
            }
            set
            {
                SetValue(CornerRadiusProperty, value);
            }
        }

        public static readonly DependencyProperty OBackgroundProperty = DependencyProperty.Register("OverBackground", typeof(Brush), typeof(CustomButton));

        public Brush OverBackground
        {
            get
            {
                return (Brush)GetValue(OBackgroundProperty);
            }
            set
            {
                SetValue(OBackgroundProperty, value);
            }
        }
    }
}
