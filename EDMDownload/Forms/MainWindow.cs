using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace EDMDownload.Forms
{
    public partial class MainWindow : Form
    {
        delegate void SetTextCallback(string text);

        public MainWindow()
        {
            InitializeComponent();
            LogHandler.OnLogReceived += new LogAddedHandler(LogHandler_OnLogReceived);
        }

        void LogHandler_OnLogReceived(string msg)
        {
            SetTextCallback d = new SetTextCallback(AddLogText);
            this.Invoke(d, new object[] { msg });
        }

        void AddLogText(string msg)
        {
            list_Log.Items.Add(msg);
            lbl_ToolStrip.Text = msg;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            LogHandler.Log("EDMDownload Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
            LogHandler.Log("Developed By Phil Smith 2013");
            LogHandler.Log("--------------------------");
            LogHandler.Log("Downloaded a total of " + MusicTrackCollection.Tracks.Count + " tracks.");
            LogHandler.Log("--------------------------");
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (num_LivingElectroPages.Value < 1)
                num_LivingElectroPages.Value = 1;
        }

        private void btn_CrawlLivingElectro_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(CrawlLivingElectro)).Start();
        }

        private void CrawlLivingElectro()
        {
            LivingElectroCrawler.MAX_PAGES = (int)num_LivingElectroPages.Value;
            LivingElectroCrawler.RunCrawl();
            foreach (MusicTrack track in MusicTrackCollection.Tracks)
            {
                if (!track.HasDownloaded && !track.LinkBroken)
                {
                    new TuneScoopDownloader(track).BeginDownload();
                    MusicTrackCollection.SaveToDisk();
                }
            }

            LogHandler.Log("Finished!");
        }
    }
}
