using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CrossPlanetDesktop.Models;

namespace CrossPlanetDesktop.Classes
{
    class Helper
    {
        public static CrossPlanetDbEntities Db = new CrossPlanetDbEntities();
        public static DateTime DateNow;

        public static bool IsExtramod = false;

        public static void Error(string error = "Ошибка БД")
        {
            MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
