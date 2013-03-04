using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using HtmlAgilityPack;
using System.IO;

namespace EDMDownload
{
    class SoundCloudCrawler
    {
        public static void RunCrawl(string page, int pagesToRun)
        {
            CookieContainer cookies = new CookieContainer();

            HttpWebRequest httpRequest = HtmlHelper.GenerateHttpRequest(page, cookies);
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)httpRequest.GetResponse();
            var html = new StreamReader(myHttpWebResponse.GetResponseStream()).ReadToEnd();

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            HtmlNodeCollection nodeCollection = doc.DocumentNode.SelectNodes("//li[@class='player']//h3/a");
            if (nodeCollection != null)
            {
                foreach (HtmlNode trackNode in nodeCollection)
                {
                    string title = System.Web.HttpUtility.UrlDecode(trackNode.InnerText).Trim();
                    string link = trackNode.GetAttributeValue("href", "");
                    LogHandler.Log("Found Track: " + title + " [Link: " + link + "]");
                }
            }
        }
    }
}
