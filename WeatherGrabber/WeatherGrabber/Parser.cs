using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WeatherGrabber
{
    public static class Parser
    {
        /// <summary>
        /// Parse info from gismetio.ru for 10 days for every city on main page
        /// </summary>
        /// <returns>
        /// Returns list of classes representing main info about weather records
        /// </returns>
        public static List<WeatherValue> GetWeatherValue()
        {
            List<WeatherValue> result = new List<WeatherValue>();

            string rootURL = @"https://www.gismeteo.ru";
            var pageContent = LoadPage(rootURL);
            var document = new HtmlDocument();
            document.LoadHtml(pageContent);



            //var links = document.DocumentNode.SelectNodes(@"//div[contains(@class, 'js_cities_pcities cities_section')]/div[contains(@class, 'cities_list')]/div[contains(@class, 'cities_item')]/a");
            var links = document.DocumentNode.SelectNodes(@"//noscript[@id='noscript']/a");
            //<div class="widget__row widget__row_date"><div class="widget__item" data-item="0"><div class="w_date"><a href="/weather-barnaul-4720/" class="link blue "><div class="w_date__day">Вт</div><span class="w_date__date black">
            string href;
            string City;
            string Cond;
            double RainF;
            int MaxT;
            int MinT;
            int Wd;

            var subDocument = new HtmlDocument();


            foreach (var link in links)
            {
                href = rootURL + link.GetAttributeValue("href", "") + @"10-days/";
                City = link.GetAttributeValue("data-name", "");
                

                Console.WriteLine("{0} - {1}", City, link.GetAttributeValue("href", ""));
                Console.WriteLine(href);
                pageContent = LoadPage(href);
                subDocument.LoadHtml(pageContent);


                var Dates = subDocument.DocumentNode.SelectNodes(@"//div[contains(@data-widget-id, 'forecast')]//div[contains(@class, 'widget__row_date')]//span[contains(@class, 'w_date__date')]");
                var Conditions = subDocument.DocumentNode.SelectNodes(@"//div[contains(@data-widget-id, 'forecast')]//div[contains(@class, 'widget__row_icon')]//span[contains(@class, 'tooltip')]");
                var MaxTemperatures = subDocument.DocumentNode.SelectNodes(@"//div[contains(@class, 'chart__temperature')]//div[contains(@class, 'maxt')]//span[contains(@class, 'unit_temperature_c')]");
                var MinTemperatures = subDocument.DocumentNode.SelectNodes(@"//div[contains(@class, 'chart__temperature')]//div[contains(@class, 'mint')]//span[contains(@class, 'unit_temperature_c')]");
                var Winds = subDocument.DocumentNode.SelectNodes(@"//div[contains(@class, 'widget__row_wind-or-gust')]//span[contains(@class, 'unit_wind_m_s')]");
                var Precipitations = subDocument.DocumentNode.SelectNodes(@"//div[contains(@class, 'widget__row_precipitation')]//div[contains(@class, 'w_prec__value')]");

                
                

                for (int i = 0; i < 10; i++)
                {
                    var dayS = Dates[i].InnerText.Trim().Split(' ');
                    DateTime dt;
                    if (i != 0 && dayS.Length > 1)
                        dt = new DateTime(day: Convert.ToInt32(dayS[0]), month: DateTime.Today.Month + 1, year: DateTime.Today.Year);
                    else
                        dt = new DateTime(day: Convert.ToInt32(dayS[0]), month: DateTime.Today.Month, year: DateTime.Today.Year);

                    try { Cond = Conditions[i].GetAttributeValue(@"data-text", "null"); }
                    catch { Cond = "Нет данных"; }
                    try { RainF = Convert.ToDouble(Precipitations[i].InnerText.Trim()); }
                    catch { RainF = 0; }
                    try { MaxT = Convert.ToInt32(MaxTemperatures[i].InnerText); }
                    catch { MaxT = 0; }
                    try { MinT = Convert.ToInt32(MinTemperatures[i].InnerText); }
                    catch { MinT = MaxT; }
                    try { Wd = Convert.ToInt32(Winds[i].InnerText); }
                    catch { Wd = 0; }

                    

                    result.Add(new WeatherValue()
                    {
                        DateTime = dt,
                        City = City,
                        Condition = Cond,
                        Rainfall = RainF,
                        MaxTemperature = MaxT,
                        MinTemperature = MinT,
                        Wind = Wd
                    });
                }

            }

            return result;
        }

        /// <summary>
        /// This method load the page
        /// </summary>
        /// <param name="url">Link to the page</param>
        /// <returns></returns>
        static string LoadPage(string url)
        {
            var result = "";
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var receiveStream = response.GetResponseStream();
                if (receiveStream != null)
                {
                    StreamReader readStream;
                    if (response.CharacterSet == null)
                        readStream = new StreamReader(receiveStream);
                    else
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    result = readStream.ReadToEnd();
                    readStream.Close();
                }
                response.Close();
            }
            return result;
        }
    }
}
