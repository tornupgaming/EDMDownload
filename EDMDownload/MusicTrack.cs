using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace EDMDownload
{
    [Serializable()]
    public class MusicTrack : ISerializable
    {
        public string Artist;
        public string Title;
        public string PageLink;
        public string DownloadLink;
        public string Genre;
        public bool HasDownloaded;
        public bool LinkBroken;

        public MusicTrack() 
        {
            Artist = string.Empty;
            Title = string.Empty;
            PageLink = string.Empty;
            DownloadLink = string.Empty;
            Genre = string.Empty;
            HasDownloaded = false;
            LinkBroken = false;
        }

        public MusicTrack(SerializationInfo info, StreamingContext context)
        {
            this.Artist = (string)info.GetValue("Artist", typeof(string));
            this.Title = (string)info.GetValue("Title", typeof(string));
            this.PageLink = (string)info.GetValue("PageLink", typeof(string));
            this.DownloadLink = (string)info.GetValue("DownloadLink", typeof(string));
            this.Genre = (string)info.GetValue("Genre", typeof(string));
            this.HasDownloaded = (bool)info.GetValue("HasDownloaded", typeof(bool));
            try
            {
                this.LinkBroken = (bool)info.GetValue("LinkBroken", typeof(bool));
            }
            catch
            {
                LinkBroken = false;
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Artist", this.Artist);
            info.AddValue("Title", this.Title);
            info.AddValue("PageLink", this.PageLink);
            info.AddValue("DownloadLink", this.DownloadLink);
            info.AddValue("Genre", this.Genre);
            info.AddValue("HasDownloaded", this.HasDownloaded);
            info.AddValue("LinkBroken", this.LinkBroken);
        }
    }
}
