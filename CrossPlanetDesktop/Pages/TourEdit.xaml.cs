using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static CrossPlanetDesktop.Classes.Helper;
using CrossPlanetDesktop.Models;


namespace CrossPlanetDesktop.Pages
{
    /// <summary>
    /// Логика взаимодействия для TourEdit.xaml
    /// </summary>
    public partial class TourEdit : Page
    {
        int _id = 0;
        public TourEdit(int id)
        {
            _id = id;
            InitializeComponent();
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            if(_id == -1)
            {
                Db.TourTask.Add(grid1.DataContext as TourTask);
            }
            Db.SaveChanges();
            NavigationService.GoBack();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if(_id == -1)
            {
                grid1.DataContext = new TourTask();
                dateDatePicker.SelectedDate = DateTime.Now;
            }
            else
            {
                grid1.DataContext = Db.TourTask.FirstOrDefault(el => el.Id == _id);
            }
        }
    }
}
