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
            MusicTrackCollection.LoadFromDisk();

            Console.WriteLine("EDMDownload Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
            Console.WriteLine("Developed By Phil Smith 2013");
            Console.WriteLine("--------------------------");
            Console.WriteLine("Downloaded a total of " + MusicTrackCollection.Tracks.Count + " tracks.");
            Console.WriteLine("--------------------------");

            Console.WriteLine("How many pages of LivingElectro.com to search through: ");
            string userIn = Console.ReadLine();
            int pages = 50;
            if (int.TryParse(userIn, out pages))
            {
                LivingElectroCrawler.MAX_PAGES = pages;
            }

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
        }
    }
}
