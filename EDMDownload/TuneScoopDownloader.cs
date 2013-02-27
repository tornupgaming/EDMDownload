using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Net;
using System.Web;

namespace EDMDownload
{
    class TuneScoopDownloader
    {
        private static List<TuneScoopDownloader> sm_CurrentDownloads = new List<TuneScoopDownloader>();
        public static void KillDownloads()
        {

        }

        private string m_TuneScoopUrl = string.Empty;
        private MusicTrack m_Track = null;

        public TuneScoopDownloader(MusicTrack track)
        {
            m_Track = track;
        }

        public void BeginDownload()
        {
            //m_DownloadThread = new Thread(new ThreadStart(DownloadFileSync));
            //m_DownloadThread.Start();
            if (m_Track.DownloadLink != null && m_Track.DownloadLink != string.Empty)
            {
                DownloadFileSync();
            }
            else
            {
                Console.WriteLine("Download Link EMPTY!!! " + m_Track.Title);
            }
        }

        private void DownloadFileSync()
        {
            Console.Write("Downloading: " + ((m_Track.Title.Length > 60) ? m_Track.Title.Substring(0, 60) : m_Track.Title) + "...");
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            watch.Start(); 
            CookieContainer cookies = new CookieContainer();

            HttpWebRequest httpRequest = HtmlHelper.GenerateHttpRequest(m_Track.DownloadLink, cookies);
            HttpWebResponse myHttpWebResponse;
            try
            {
                myHttpWebResponse = (HttpWebResponse)httpRequest.GetResponse();
            }
            catch (System.Net.WebException webEx)
            {
                if (webEx.Status == WebExceptionStatus.ProtocolError)
                {
                    Console.WriteLine("(BROKEN LINK)");
                    m_Track.LinkBroken = true;
                }

                return;
            }
            var html = new StreamReader(myHttpWebResponse.GetResponseStream()).ReadToEnd();

            string csrfString = html.Split(new string[] { "csrfmiddlewaretoken' value='" }, StringSplitOptions.None)[1]
                .Split(new string[] { "'" }, StringSplitOptions.None)[0];

            httpRequest = HtmlHelper.GenerateHttpRequest(m_Track.DownloadLink, cookies, "csrfmiddlewaretoken=" + csrfString + "&dl=1");
            myHttpWebResponse = (HttpWebResponse)httpRequest.GetResponse();
            html = new StreamReader(myHttpWebResponse.GetResponseStream()).ReadToEnd();

            string downloadURL = html.Split(new string[] { "action=\"" }, StringSplitOptions.None)[1]
                .Split(new string[] { "\"" }, StringSplitOptions.None)[0];

            string cid = GetPostValueFromPostName(html, "cid");
            string token = HttpUtility.UrlEncode(GetPostValueFromPostName(html, "token"));
            string cdt = GetPostValueFromPostName(html, "cdt");
            string hash = GetPostValueFromPostName(html, "hash");
            string filename = GetPostValueFromPostName(html, "filename");
            string encodedFilename = HttpUtility.UrlEncode(filename);

            filename = filename.Replace("www.LivingElectro.com","");
            filename = filename.Replace("www.livingelectro.com","");
            filename = filename.Replace("&amp;","&");
            filename = filename.Replace("&#39;", "'");
            filename = filename.Replace(" []", "");
            filename = filename.Replace("[]", "");


            string postData = "cid=" + cid + "&token=" + token + "&cdt=" + cdt + "&hash=" + hash + "&filename=" + encodedFilename;

            httpRequest = HtmlHelper.GenerateHttpRequest(downloadURL, cookies, postData);
            myHttpWebResponse = (HttpWebResponse)httpRequest.GetResponse();
            Stream stream = myHttpWebResponse.GetResponseStream();

            if (!Directory.Exists(m_Track.Genre))
            {
                Directory.CreateDirectory(m_Track.Genre);
            }

            FileStream fs = new FileStream(m_Track.Genre + "/" + filename, FileMode.Create);

            byte[] read = new byte[512];

            int count = stream.Read(read, 0, read.Length);

            while (count > 0)
            {
                fs.Write(read, 0, count);
                count = stream.Read(read, 0, read.Length);
            }
            fs.Close();
            stream.Close();
            myHttpWebResponse.Close();
            m_Track.HasDownloaded = true;

            watch.Stop();
            Console.WriteLine("(" + watch.ElapsedMilliseconds.ToString("N0") + "ms)");
            
        }

        private string GetPostValueFromPostName(string html, string postName)
        {
            return html.Split(new string[] { "name=\"" + postName + "\" value=\"" }, StringSplitOptions.None)[1]
                .Split(new string[] { "\"" }, StringSplitOptions.None)[0];
        }

        

        private void KillDownload()
        {

        }
    }
}
