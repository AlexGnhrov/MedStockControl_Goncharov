using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MedStockControl_Goncharov.ClassFolder
{
    class MBClass
    {
        public static void Error(String text)
        {
            MessageBox.Show(text,
                "Ошибка",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
        public static void Error(Exception ex)
        {
            MessageBox.Show(ex.Message,
                "Ошибка",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
        public static void Info(String text)
        {
            MessageBox.Show(text,
                "Информация",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
        public static bool Question(String text)
        {
            return MessageBoxResult.Yes == MessageBox.Show(text,
                "Вопрос",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);
        }
        public static void Exit()
        {
            bool res = Question("Вы действительно желаете выйти?");
           if (res ==true)
            {
                App.Current.Shutdown();
            }
        }
    }
}
