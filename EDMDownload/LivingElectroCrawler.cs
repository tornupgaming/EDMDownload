using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using HtmlAgilityPack;
using System.Web;

namespace EDMDownload
{
    class LivingElectroCrawler
    {
        public static int MAX_PAGES = 50;

        public static void RunCrawl()
        {
            CookieContainer cookies = new CookieContainer();

            for (int i = 0; i < MAX_PAGES; i++)
            {
                Console.WriteLine("Loading Page: " + (i+1).ToString());
                HttpWebRequest httpRequest = HtmlHelper.GenerateHttpRequest("http://www.livingelectro.com/All/" + (i+1).ToString(), cookies);
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)httpRequest.GetResponse();
                var html = new StreamReader(myHttpWebResponse.GetResponseStream()).ReadToEnd();

                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);
                ParseTrackList(doc);
                Console.WriteLine("Finished Page: " + (i + 1).ToString());
                MusicTrackCollection.SaveToDisk();
            }

            foreach (MusicTrack track in MusicTrackCollection.Tracks)
            {
                if (track.DownloadLink == null || track.DownloadLink == string.Empty)
                {
                    if (track.PageLink.Contains("www.livingelectro.com"))
                    {
                        GetDownloadLinkForLETrack(track);
                        MusicTrackCollection.SaveToDisk();
                    }
                }
            }

            Console.WriteLine("Finished Living Electro Crawl");
        }

        private static void GetDownloadLinkForLETrack(MusicTrack track)
        {
            Console.Write("Get download link: " + ((track.Title.Length > 50) ? track.Title.Substring(0, 50) : track.Title)+"...");
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            HttpWebRequest httpRequest = HtmlHelper.GenerateHttpRequest(track.PageLink, new CookieContainer());
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)httpRequest.GetResponse();
            var html = new StreamReader(myHttpWebResponse.GetResponseStream()).ReadToEnd();

            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            HtmlNode downloadNode = doc.DocumentNode.SelectSingleNode("//div[@class='song_download_link']");
            HtmlNode hrefNode = downloadNode.SelectSingleNode("a");
            if (hrefNode != null)
            {
                track.DownloadLink = hrefNode.GetAttributeValue("href", "");
            }
            watch.Stop();
            Console.WriteLine("("+watch.ElapsedMilliseconds.ToString("N0")+"ms)");
        }

        private static void ParseTrackList(HtmlDocument doc)
        {
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//div[@class='song_item']"))
            {
                MusicTrack newTrack = new MusicTrack();
                HtmlNode titleNode = node.SelectSingleNode("div[@class='song_item_title']");
                if (titleNode != null)
                {
                    newTrack.Title = HttpUtility.UrlDecode(titleNode.InnerText).Trim();
                    HtmlNode hrefNode = titleNode.SelectSingleNode("a");
                    if (hrefNode != null)
                    {
                        newTrack.PageLink = hrefNode.GetAttributeValue("href", "");
                        newTrack.Genre = newTrack.PageLink.Split('/')[1];
                        newTrack.PageLink = "http://www.livingelectro.com/" + newTrack.PageLink;
                    }
                }

                HtmlNode artistNode = node.SelectSingleNode("div[@class='song_item_artist']");
                if (artistNode != null)
                {
                    newTrack.Artist = HttpUtility.UrlDecode(artistNode.InnerText).Trim();
                }

                if (newTrack.PageLink == string.Empty || newTrack.Genre == string.Empty || newTrack.Genre.CompareTo("media") == 0)
                {
                    return;
                }

                MusicTrackCollection.AddTrack(newTrack);
            }
        }
    }
}
