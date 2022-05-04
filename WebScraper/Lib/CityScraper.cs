using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using HtmlAgilityPack;

namespace WebScraper.Lib
{
    public static class CityScraper
    {
        public static void CityScraperToFile(List<string> countries, string fileLoc)
        {
            var web = new HtmlWeb();
          
            foreach (var country in countries)
            {
                var doc = web.Load(country);
                var table = doc.QuerySelectorAll("table")[2];
                var tableRows = table.QuerySelectorAll("tr").Skip(1);
                foreach (var tableRow in tableRows)
                {
                    var tds = tableRow.QuerySelectorAll("td");
                    var city = tds[2].InnerText;
                    using (StreamWriter sw = File.AppendText(fileLoc))
                    {
                        if (city.Contains('&') && !city.Contains('#'))
                        {
                            var city1 = city.Substring(0, city.LastIndexOf('&'));
                            sw.WriteLine(city1);
                        }

                        if (city.Contains('#') && !city.Contains('&'))
                        {
                            var city2 = city.Substring(0, city.LastIndexOf('#'));
                            sw.WriteLine(city2);
                        }
                        if (city.Contains('#') || !city.Contains('&'))
                        {
                            var city1 = city.Substring(0, city.LastIndexOf('&'));
                            var city2 = city1.Substring(0, city1.LastIndexOf('#'));
                            sw.WriteLine(city2);
                        }
                        //TODO: poprawne ucinanie nazw tych miast
                    }
                }
            }
        }
    }
}