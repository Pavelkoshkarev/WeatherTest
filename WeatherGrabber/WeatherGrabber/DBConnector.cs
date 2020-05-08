using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherGrabber
{
    public static class DBConnector
    {
        public static string host = "localhost";
        public static string dbName = "weather";
        public static string uid = "admin";
        public static string pwd = "";




        public static void SaveWValuesToDB(List<WeatherValue> valueList)
        {
            using (MySqlConnection con = new MySqlConnection("Server = " + host + "; Database = " + dbName + "; Uid = " + uid + "; Pwd = " + pwd + ";"))
            {
                con.Open();

                foreach (WeatherValue value in valueList)
                {
                    using (MySqlCommand cmd = new MySqlCommand("weather.AddWeatherRow", con) { CommandType = System.Data.CommandType.StoredProcedure })
                    {
                        cmd.Parameters.AddWithValue("pCity", value.City.Normalize());
                        cmd.Parameters.AddWithValue("pDate", value.DateTime.Date);
                        cmd.Parameters.AddWithValue("pTime", value.DateTime.TimeOfDay);
                        cmd.Parameters.AddWithValue("pTempMax", value.MaxTemperature);
                        cmd.Parameters.AddWithValue("pTempMin", value.MinTemperature);
                        cmd.Parameters.AddWithValue("pWind", value.Wind);
                        cmd.Parameters.AddWithValue("pRainFall", value.Rainfall);
                        cmd.Parameters.AddWithValue("pCondition", value.Condition.Normalize());

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }


    }
}
