using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace EDMDownload
{
    [Serializable()]
    public class MusicTrackCollection : ISerializable
    {
        public static List<MusicTrack> Tracks = new List<MusicTrack>();
        public static void SaveToDisk()
        {
            new MusicTrackSerializer().SerializeObject(new MusicTrackCollection());
        }
        public static void LoadFromDisk()
        {
            new MusicTrackSerializer().DeSerializeObject();
        }

        public static void AddTrack(MusicTrack track)
        {
            for (int i = 0; i < Tracks.Count; i++)
            {
                MusicTrack t_Track = Tracks[i];
                if (track.PageLink.CompareTo(t_Track.PageLink) == 0)
                {
                    return;
                }
            }

            LogHandler.Log("New Track Added To Collection: " + ((track.Title.Length > 60) ? track.Title.Substring(0, 60) : track.Title));
            Tracks.Add(track);
        }

        public MusicTrackCollection() { }

        public MusicTrackCollection(SerializationInfo info, StreamingContext ctxt)
        {
            Tracks = (List<MusicTrack>)info.GetValue("Tracks", typeof(List<MusicTrack>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Tracks", Tracks);
        }
    }
}
