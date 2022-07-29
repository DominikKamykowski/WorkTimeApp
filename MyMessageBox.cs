using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CzasPracy
{
    static class MyMessageBox
    {
        public static void ShowWarningMessageBox(string text)
        {
            MessageBoxImage image = MessageBoxImage.Warning;
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBox.Show(text, "Warning", button, image);
        }
    }
}
