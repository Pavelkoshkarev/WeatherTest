using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfWeather
{
    public class ServiceWeather : IServiceWeather
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<string> GetCities()
        {
            return DBConnector.GetCities();
        }

        public WeatherCityDay GetWeatherForCityAndDay(string city, DateTime day)
        {
            return DBConnector.GetWeatherForCityAndDay(city, day);
        }
    }
}
