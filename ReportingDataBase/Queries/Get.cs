using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace ReportingDataBase.Queries
{
    public class GetQueries
    {
        public static string GET(string Url, string Data, string Field)
        {
            using (WebClient wc = new WebClient())
                            {
                var json = wc.DownloadString(Url + "?" + Data);
                JObject obj = JObject.Parse(json);
                string result = (string)obj[0]["quantity"];
                                return result;
                            }
        }
    }
}