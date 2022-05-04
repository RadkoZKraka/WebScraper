using System;
using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using HtmlAgilityPack;

namespace WebScraper.Lib
{
    public class CountryScraper
    {
        
        public void GetCountries(string url, string fileLoc)
        {
            var web = new HtmlWeb();
            var doc = web.Load(url);
            var tableRows = doc.QuerySelectorAll("table tr").Skip(1);
            List<string> countriesLink = new List<string>();
            foreach (var tableRow in tableRows)
            {
                var tds = tableRow.QuerySelectorAll("td");

                var code = tds[0].InnerText;
                var name = tds[1].InnerText;

                countriesLink.Add(tds[1].QuerySelector("a").Attributes["href"].Value);
            }
            
            CityScraper.CityScraperToFile(countriesLink, fileLoc);
            
        }
    }
}