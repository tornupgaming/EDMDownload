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

            for (int i = 0; i < pagesToRun; i++)
            {
                HttpWebRequest httpRequest = HtmlHelper.GenerateHttpRequest("https://soundcloud.com/" + page, cookies);
                HttpWebResponse myHttpWebResponse = (HttpWebResponse)httpRequest.GetResponse();
                var html = new StreamReader(myHttpWebResponse.GetResponseStream()).ReadToEnd();

                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);
                HtmlNodeCollection nodeCollection = doc.DocumentNode.SelectNodes("//li[@class='player']//h3/a");
                if (nodeCollection != null)
                {
                    foreach (HtmlNode trackNode in nodeCollection)
                    {
                        MusicTrack newMusicTrack = new MusicTrack();
                        newMusicTrack.Genre = page;
                        newMusicTrack.Title = System.Web.HttpUtility.UrlDecode(trackNode.InnerText).Trim();
                        newMusicTrack.PageLink = "https://soundcloud.com" + trackNode.GetAttributeValue("href", "");
                        MusicTrackCollection.AddTrack(newMusicTrack);
                        LogHandler.Log("Found Track: " + newMusicTrack.Title + " [Link: " + newMusicTrack.PageLink + "]");
                    }
                }

                MusicTrackCollection.SaveToDisk();
            }

            foreach (MusicTrack track in MusicTrackCollection.Tracks)
            {
                if (track.PageLink.StartsWith("https://soundcloud.com/"))
                {
                    HttpWebRequest httpRequest = HtmlHelper.GenerateHttpRequest(track.PageLink, cookies);
                    HttpWebResponse myHttpWebResponse = (HttpWebResponse)httpRequest.GetResponse();
                    var html = new StreamReader(myHttpWebResponse.GetResponseStream()).ReadToEnd();

                    httpRequest = HtmlHelper.GenerateHttpRequest(track.PageLink + "/download", cookies);
                    myHttpWebResponse = (HttpWebResponse)httpRequest.GetResponse();
                    Stream stream = myHttpWebResponse.GetResponseStream();

                    if (!Directory.Exists(track.Genre))
                    {
                        Directory.CreateDirectory(track.Genre);
                    }

                    string filename = track.Title + ".mp3";

                    FileStream fs = new FileStream(track.Genre + "/" + filename, FileMode.Create);
                    LogHandler.Log("Downloading file: " + filename +
                        " (" + (myHttpWebResponse.ContentLength / 1024.0f / 1024.0f).ToString("N2") + "MB)");
                    byte[] read = new byte[512];
                    int readBytes = 0;
                    int count = stream.Read(read, 0, read.Length);

                    while (count > 0)
                    {
                        fs.Write(read, 0, count);
                        count = stream.Read(read, 0, read.Length);
                        readBytes += read.Length;
                        float perc = (100.0f / (float)myHttpWebResponse.ContentLength) * (float)readBytes;
                        LogHandler.ChangeProgressBar((int)perc);
                    }
                    fs.Close();
                    stream.Close();
                    myHttpWebResponse.Close();
                    track.HasDownloaded = true;
                }
            }

            LogHandler.Log("Completed SoundCloud crawl!");
        }
    }
}
