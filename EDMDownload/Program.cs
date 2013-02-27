using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;

namespace EDMDownload
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("EDMDownload Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
            Console.WriteLine("Developed By Phil Smith 2013");
            Console.WriteLine("--------------------------");
            MusicTrackCollection.LoadFromDisk();


            LivingElectroCrawler.RunCrawl();
            foreach (MusicTrack track in MusicTrackCollection.Tracks)
            {
                if (!track.HasDownloaded && !track.LinkBroken)
                {
                    new TuneScoopDownloader(track).BeginDownload();
                    MusicTrackCollection.SaveToDisk();
                }
            }

            Console.WriteLine("Finished!");
            Console.ReadLine();


            //MusicTrack myTrack = new MusicTrack() {
            //    Artist = "Avicii vs. Nicky Romero",
            //    Title = "I Could Be The One (John Christian Remix)",
            //    Genre = "House",
            //    DownloadLink = "http://www.tunescoop.com/play/313632353434/avicii-vs-nicky-romero-i-could-be-the-one-john-christian-remixwwwlivingelectrocom-mp3"
            //};


            //new TuneScoopDownloader(myTrack).BeginDownload();
        }
    }
}
