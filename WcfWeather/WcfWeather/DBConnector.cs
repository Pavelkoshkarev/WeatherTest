using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfWeather
{
    public class DBConnector
    {
        public static string host = "localhost";
        public static string dbName = "weather";
        public static string uid = "admin";
        public static string pwd = "";
        static string connectionRow => "Server = " + host + "; Database = " + dbName + "; Uid = " + uid + "; Pwd = " + pwd + ";";

        public static List<string> GetCities()
        {
            List<string> result = new List<string>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionRow))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand("SELECT distinct City FROM weather", con))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                                while (reader.Read())
                                {
                                    result.Add(reader[0].ToString());
                                }
                        }
                    }
                }
            }
            catch { }
            return result;
        }

        public static WeatherCityDay GetWeatherForCityAndDay(string city, DateTime day)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionRow))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(@"SELECT ConditionComment, TemperatureMax, TemperatureMin, Wind, Rainfall FROM weather
                                                                WHERE City = @pCity AND Date = @pDate", con) )
                    {
                        cmd.Parameters.AddWithValue("@pCity", city);
                        cmd.Parameters.AddWithValue("@pDate", day.Date);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                                while (reader.Read())
                                {
                                    return new WeatherCityDay()
                                    {
                                        City = city,
                                        Day = day.Date,
                                        ConditionComment = reader[0].ToString(),
                                        TemperatureMax = Convert.ToInt32(reader[1]),
                                        TemperatureMin = Convert.ToInt32(reader[2]),
                                        Wind = Convert.ToInt32(reader[3]),
                                        Rainfall = float.Parse(reader[4].ToString())
                                    };
                                }
                        }
                    }
                }
            }
            catch
            {

            }
            return new WeatherCityDay();

        }
    }
}