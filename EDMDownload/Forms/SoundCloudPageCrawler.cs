using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace EDMDownload.Forms
{
    public partial class SoundCloudPageCrawler : Form
    {
        public int MaxTracks = 10;
        private bool m_DocComplete;
        private int scrollHeight = 0;
        private const int SCROLL_INCREMENT = 500;
        private int pageNumber = 1;
        private string pageToLoad = string.Empty;

        CookieContainer cookies = new CookieContainer();

        public SoundCloudPageCrawler(string page)
        {
            InitializeComponent();
            HttpWebRequest httpRequest = HtmlHelper.GenerateHttpRequest(page, cookies);
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)httpRequest.GetResponse();
            var html = new StreamReader(myHttpWebResponse.GetResponseStream()).ReadToEnd();

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            HtmlAgilityPack.HtmlNodeCollection nodeCollection = doc.DocumentNode.SelectNodes(
                "//li[@class='player']//h3/a"
                );
            if (nodeCollection != null)
            {
                foreach (HtmlAgilityPack.HtmlNode trackNode in nodeCollection)
                {
                    string title = System.Web.HttpUtility.UrlDecode(trackNode.InnerText).Trim();
                    string link = trackNode.GetAttributeValue("href", "");
                    LogHandler.Log("Found Track: " + title + " [Link: " + link + "]");
                }
            }
            else
            {
                LogHandler.Log("MASSIVE ERROR: SoundCloud page was null of tracks");
            }





            //web_SoundCloud.ScriptErrorsSuppressed = true;
            //web_SoundCloud.Navigate(page);
            //pageToLoad = page;
        }

        private void timer_Update_Tick(object sender, EventArgs e)
        {
            if (m_DocComplete)
            {
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(web_SoundCloud.DocumentText);
                HtmlAgilityPack.HtmlNodeCollection nodeCollection = doc.DocumentNode.SelectNodes(
                    "//li[@class='player']//h3/a"
                    );
                if (nodeCollection != null)
                {
                    foreach (HtmlAgilityPack.HtmlNode trackNode in nodeCollection)
                    {
                        string title = System.Web.HttpUtility.UrlDecode(trackNode.InnerText).Trim();
                        string link = trackNode.GetAttributeValue("href", "");
                        LogHandler.Log("Found Track: " + title + " [Link: " + link + "]");
                    }
                }
                else
                {
                    LogHandler.Log("MASSIVE ERROR: SoundCloud page was null of tracks");
                }

                m_DocComplete = false;
                pageNumber++;
                web_SoundCloud.Navigate(pageToLoad + "/tracks?format=html&page=" + pageNumber);
            }
        }

        private void web_SoundCloud_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            m_DocComplete = true;
        }
    }
}
