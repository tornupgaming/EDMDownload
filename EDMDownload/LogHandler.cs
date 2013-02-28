using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDMDownload
{
    public delegate void LogAddedHandler(string msg);
    public delegate void ProgressBarHandler(int percent);

    class LogHandler
    {
        public static event LogAddedHandler OnLogReceived;
        public static event ProgressBarHandler OnProgressBarChanged;

        private static void LogReceived(string msg){
            if (OnLogReceived != null)
            {
                OnLogReceived(msg);
            }
        }

        private static void ProgressBarChanged(int percent)
        {
            if (OnProgressBarChanged != null)
            {
                OnProgressBarChanged(percent);
            }
        }

        public static void Log(string msg)
        {
            LogReceived(msg);
        }

        public static void ChangeProgressBar(int percent)
        {
            ProgressBarChanged(percent);
        }
    }
}
