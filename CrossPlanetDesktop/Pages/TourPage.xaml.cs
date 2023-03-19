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
using System.Windows.Threading;

namespace CrossPlanetDesktop.Pages
{
    /// <summary>
    /// Логика взаимодействия для TourPage.xaml
    /// </summary>
    public partial class TourPage : Page
    {
        DispatcherTimer timer = new DispatcherTimer();
        public TourPage()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(0, 0, 10);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                tourTaskDataGrid.ItemsSource = Db.TourTask.ToList();
                pointDataGrid.ItemsSource = Db.Point.ToList();
            }
            catch (Exception ex)
            {

                Error(ex.Message);

            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void AddBtn1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TourEdit(-1));
        }

        private void EditBtn1_Click(object sender, RoutedEventArgs e)
        {
            if (tourTaskDataGrid.SelectedItem != null)
            {
                var item = tourTaskDataGrid.SelectedItem as TourTask;
                NavigationService.Navigate(new TourEdit(item.Id));
                LoadData();
            }
        }

        private void DelBtn1_Click(object sender, RoutedEventArgs e)
        {
            if(tourTaskDataGrid.SelectedItem != null)
            {
                var item = tourTaskDataGrid.SelectedItem as TourTask;
                Db.TourTask.Remove(item);
                Db.SaveChanges();
                LoadData();
            }

        }

        private void AddBtn2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditBtn2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DelBtn2_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
