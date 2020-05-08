using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherClient.ServiceWeather;

namespace WeatherClient
{
    class MainWindowVM: INotifyPropertyChanged
    {
        ServiceWeatherClient swClient;

        public MainWindowVM()
        {
            
            swClient = new ServiceWeatherClient();
            selectedDate = DateTime.Today;
            LoadCities();
            LoadFunction();
            loadCommand = new DelegateCommand(LoadFunction);

        }

        private DateTime selectedDate;
        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set
            {
                selectedDate = value;
                NotifyPropertyChanged();
            }
        }

        private ICommand loadCommand;
        public ICommand LoadCommand => loadCommand;

        private void LoadFunction()
        {
           Info = swClient.GetWeatherForCityAndDay(SelectedCity, SelectedDate);
        }

        public void LoadCities()
        {
            CitiesList = swClient.GetCities().ToList();
            SelectedCity = CitiesList.First();
        }

        private WeatherCityDay info;
        public WeatherCityDay Info
        {
            get => info;
            set
            {
                info = value;  
                NotifyPropertyChanged();
            }
        }


        private List<string> citiesList;
        public List<string> CitiesList
        {
            get => citiesList;
            set
            {
                citiesList = value;
                NotifyPropertyChanged();
            }
        }

        private string selectedCity = "";
        public string SelectedCity
        {
            get => selectedCity;
            set
            {
                selectedCity = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
