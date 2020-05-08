using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfWeather
{
    [ServiceContract]
    public interface IServiceWeather
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        List<string> GetCities();

        [OperationContract]
        WeatherCityDay GetWeatherForCityAndDay(string city, DateTime day);
    }


    [DataContract]
    public class WeatherCityDay
    {
        DateTime day;
        string city;
        string conditionComment;
        int temperatureMax;
        int temperatureMin;
        int wind;
        float rainfall;

        [DataMember]
        public DateTime Day
        {
            get { return day; }
            set { day = value; }
        }

        [DataMember]
        public string ConditionComment
        {
            get { return conditionComment; }
            set { conditionComment = value; }
        }


        [DataMember]
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        [DataMember]
        public int TemperatureMax
        {
            get { return temperatureMax; }
            set { temperatureMax = value; }
        }

        [DataMember]
        public int TemperatureMin
        {
            get { return temperatureMin; }
            set { temperatureMin = value; }
        }

        [DataMember]
        public int Wind
        {
            get { return wind; }
            set { wind = value; }
        }

        [DataMember]
        public float Rainfall
        {
            get { return rainfall; }
            set { rainfall = value; }
        }

    }

    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
