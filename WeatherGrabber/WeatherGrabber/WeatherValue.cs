using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherGrabber
{
    /// <summary>
    /// Represent records about weather
    /// </summary>
    public class WeatherValue
    {
        public string City;
        public string Condition;
        public DateTime DateTime;
        public int MaxTemperature;
        public int MinTemperature;
        public int Wind;
        public double Rainfall;


    }
}
