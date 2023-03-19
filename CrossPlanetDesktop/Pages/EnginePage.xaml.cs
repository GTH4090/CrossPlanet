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
    /// Логика взаимодействия для EnginePage.xaml
    /// </summary>
    public partial class EnginePage : Page
    {
        DispatcherTimer Timer = new DispatcherTimer();
        public EnginePage()
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
                engineLogsDataGrid.ItemsSource = Db.EngineLogs.ToList();
            }
            catch (Exception ex)
            {

                Error(ex.Message);
            }
        }

        private void AddBtn1_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void EditBtn1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DelBtn1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}
