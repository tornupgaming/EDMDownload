using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDMDownload
{
    public delegate void LogAddedHandler(string msg);

    class LogHandler
    {
        public static event LogAddedHandler OnLogReceived;

        private static void LogReceived(string msg){
            if (OnLogReceived != null)
            {
                OnLogReceived(msg);
            }
        }

        public static void Log(string msg)
        {
            LogReceived(msg);
        }
    }
}
