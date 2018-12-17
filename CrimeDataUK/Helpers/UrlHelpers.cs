using System;
using System.Net;

namespace CrimeDataUK.Helpers
{
    public class UrlHelpers
    {
        public static string GetUrlString(string url)
        {
            string json = "";
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString(url);
            }
            return json;
        }
    }
}
