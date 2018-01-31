using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace ReportingDataBase.Queries
{
    public class Get
    {
        public static string GET(string Url, string Data)
        {
            WebRequest req = WebRequest.Create(Url + "?" + Data);
            WebResponse resp = req.GetResponse();
            Stream stream = resp.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string Out = sr.ReadToEnd();
            sr.Close();
            return Out;
        }
    }
}