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
    /// Логика взаимодействия для ResoursesPage.xaml
    /// </summary>
    public partial class ResoursesPage : Page
    {
        DispatcherTimer Timer = new DispatcherTimer();
        
        public ResoursesPage()
        {
            InitializeComponent();
            Timer.Interval = new TimeSpan(0, 0, 10);
            Timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                resoursesLogsDataGrid.ItemsSource = Db.ResoursesLogs.OrderByDescending(el => el.Date).ToList();
            }
            catch (Exception ex)
            {

                Error(ex.Message);
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ResoursesEdit(-1));
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (resoursesLogsDataGrid.SelectedItem != null)
            {
                var item = resoursesLogsDataGrid.SelectedItem as ResoursesLogs;
                NavigationService.Navigate(new ResoursesEdit(item.Id));
            }
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            if(resoursesLogsDataGrid.SelectedItem != null)
            {
                var item = resoursesLogsDataGrid.SelectedItem as ResoursesLogs;
                Db.ResoursesLogs.Remove(item);
                Db.SaveChanges();
                LoadData();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}
