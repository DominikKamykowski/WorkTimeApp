using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CzasPracy
{
    /// <summary>
    /// Klasa MessageBox'ów
    /// </summary>
    static class MyMessageBox
    {
        /// <summary>
        /// Metoda wyświetlająca MessageBox typu Warning.
        /// </summary>
        /// <param name="text"></param>
        public static void ShowWarningMessageBox(string text)
        {
            MessageBoxImage image = MessageBoxImage.Warning;
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBox.Show(text, "Warning", button, image);
        }
    }
}
