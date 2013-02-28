using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;
using EDMDownload.Forms;

namespace EDMDownload
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            MusicTrackCollection.LoadFromDisk();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
