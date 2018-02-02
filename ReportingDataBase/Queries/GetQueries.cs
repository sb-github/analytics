using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace ReportingDataBase.Queries
{
    public class GetQueries
    {
        public static string GET(string Url, string Data, string Field)
        {
            //WebRequest req = WebRequest.Create(Url + "?" + Data);
            //WebResponse resp = req.GetResponse();
            //Stream stream = resp.GetResponseStream();
            //StreamReader sr = new StreamReader(stream);
            //string Out = sr.ReadToEnd();
            //sr.Close();
            //return Out;            

            using (WebClient wc = new WebClient())
            {
                try
                {
                    var json = wc.DownloadString(Url + "?" + Data);
                    JArray obj = JArray.Parse(json);
                    string result = (string)obj[0][Field];
                    return result;
                }
                catch
                {
                    return "0";
                }
            }            
        }
    }
}