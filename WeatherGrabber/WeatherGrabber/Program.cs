using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherGrabber
{
    class Program
    {
        static void Main(string[] args)
        {
            DBConnector.SaveWValuesToDB(Parser.GetWeatherValue());
        }
    }
}
