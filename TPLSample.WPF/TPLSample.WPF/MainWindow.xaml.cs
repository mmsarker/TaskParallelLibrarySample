using Mizan.Covid19.Library;
using Mizan.Covid19.Library.Models;
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

namespace TPLSample.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.DataGrid1.ItemsSource = new List<CountrySummary>();
                this.Progress.Visibility = Visibility.Visible;
                this.Progress.IsIndeterminate = true;
                var covid19ApiClient = new Covid19ApClient();
                //var summary = await covid19ApiClient.GetSummaryAsync();

                await Task.Run(() =>
                {
                    var summary = covid19ApiClient.GetSummary();                    
                    return summary.Countries;
                    

                }).ContinueWith(async (continuationTask) =>
               {
                   var countries = await continuationTask;
                   Dispatcher.Invoke(() =>
                   {
                       this.DataGrid1.ItemsSource = countries;
                   });
               }, TaskContinuationOptions.OnlyOnRanToCompletion);

                this.Status.Text = "Completed";
            }
            catch (Exception)
            {

                MessageBox.Show("Error happened");
            }

            this.Progress.Visibility = Visibility.Hidden;
        }

        private void CountryListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private async void ButtonLoadCountry_Click(object sender, RoutedEventArgs e)
        {
            LoadCountries();
        }


        private async void LoadCountries()
        {
            this.CountryListBox.ItemsSource = new List<CountryData>();
            this.Progress.Visibility = Visibility.Visible;
            this.Progress.IsIndeterminate = true;

            var covid19ApiClient = new Covid19ApClient();
            var countries = await covid19ApiClient.GetCountryDataAsync();
            this.CountryListBox.ItemsSource = countries;
            this.CountryListBox.DisplayMemberPath = "Country";

            this.Progress.Visibility = Visibility.Hidden;
        }

        private async void ButtonLoadByCountry_Click(object sender, RoutedEventArgs e)
        {

            this.Progress.Visibility = Visibility.Visible;
            this.Progress.IsIndeterminate = true;
            var covid19ApiClient = new Covid19ApClient();
            //var summary = await covid19ApiAdapter.GetSummaryAsync();
            //var summary = covid19ApiAdapter.GetSummary();
            //this.DataGrid1.ItemsSource = summary.Countries;

            var countries = await covid19ApiClient.GetCountryDataAsync();
            this.CountryListBox.ItemsSource = countries;
            this.CountryListBox.DisplayMemberPath = "Country";
        }
    }
}
