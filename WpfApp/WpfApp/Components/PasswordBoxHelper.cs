using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace WpfApp.Components
{
    public static class PasswordBoxHelper
    {
        public static readonly DependencyProperty BoundPasswordProperty =
            DependencyProperty.RegisterAttached("BoundPassword", typeof(string), typeof(PasswordBoxHelper),
                new PropertyMetadata(string.Empty, OnBoundPasswordChanged));

        public static readonly DependencyProperty AttachPasswordProperty =
            DependencyProperty.RegisterAttached("AttachPassword", typeof(bool), typeof(PasswordBoxHelper),
                new PropertyMetadata(false, OnAttachPasswordChanged));

        public static string GetBoundPassword(DependencyObject obj)
        {
            return (string)obj.GetValue(BoundPasswordProperty);
        }

        public static void SetBoundPassword(DependencyObject obj, string value)
        {
            obj.SetValue(BoundPasswordProperty, value);
        }

        public static bool GetAttachPassword(DependencyObject obj)
        {
            return (bool)obj.GetValue(AttachPasswordProperty);
        }

        public static void SetAttachPassword(DependencyObject obj, bool value)
        {
            obj.SetValue(AttachPasswordProperty, value);
        }

        private static void OnBoundPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PasswordBox passwordBox && !passwordBox.Password.Equals((string)e.NewValue))
            {
                passwordBox.Password = (string)e.NewValue;
            }
        }

        private static void OnAttachPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PasswordBox passwordBox)
            {
                if ((bool)e.NewValue)
                {
                    passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
                }
                else
                {
                    passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;
                }
            }
        }

        private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox)
            {
                var newPassword = passwordBox.Password;
                SetBoundPassword(passwordBox, newPassword);

                // Explicitly trigger the update of the source binding
                var bindingExpression = passwordBox.GetBindingExpression(BoundPasswordProperty);
                bindingExpression?.UpdateSource();
            }
        }
    }
}
