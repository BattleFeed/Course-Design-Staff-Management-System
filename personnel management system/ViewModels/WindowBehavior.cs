using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;

namespace PersonnelManagementSystem.ViewModels
{
    class WindowBehavior: Behavior<Window>
    {
        /// <summary>
        /// 关闭窗口
        /// </summary>
        private static void OnCloseChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var window = ((WindowBehavior)obj).AssociatedObject;
            var newValue = (bool)args.NewValue;
            if (newValue)
            {
                window.Close();
            }
        }

        public static readonly DependencyProperty CloseProperty =
            DependencyProperty.Register("Close", typeof(bool), typeof(WindowBehavior), new PropertyMetadata(false, OnCloseChanged));

        public bool Close
        {
            get { return (bool)GetValue(CloseProperty); }
            set { SetValue(CloseProperty, value); }
        } 
    }
}
