using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApplication.Commands;
using WeatherApplication.Helpers;
using WeatherApplication.Models;

namespace WeatherApplication.ViewModels
{
    public class WeatherVM : INotifyPropertyChanged
    {
        private string context;
        public string Context
        {
            get { return context; }
            set { context = value; OnPropertyChanged("Context"); }
        }

        private City selectedCity;
        public City SelectedCity
        {
            get { return selectedCity; }
            set { selectedCity = value; OnPropertyChanged("SelectedCity"); GetCurrentConditions(); }
        }

        private CurrentConditions currentConditions;
        public CurrentConditions CurrentConditions
        {
            get { return currentConditions; }
            set { currentConditions = value; OnPropertyChanged("CurrentConditions");  }
        }

        public ObservableCollection<City> Cities { get; set; }
        public SearchCommand SearchCommand { get; set; }

        public WeatherVM()
        {
            Cities = new ObservableCollection<City>();
            SearchCommand = new SearchCommand(this);
        }

        public async void GetCities()
        {
            var cities = await AccuWeatherHelper.GetCities(Context);
            Cities.Clear();
            foreach (City city in cities)
            {
                Cities.Add(city);
            }
        }

        private async void GetCurrentConditions()
        {
            CurrentConditions = await AccuWeatherHelper.GetCurrentConditions(selectedCity.Key); 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
