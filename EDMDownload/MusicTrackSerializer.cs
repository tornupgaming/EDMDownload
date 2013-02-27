using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System;

namespace EDMDownload
{
    public class MusicTrackSerializer
    {
        private const string TRACK_LIST_FILENAME = "TrackList.edm";

        public MusicTrackSerializer()
        {
        }

        public void SerializeObject(MusicTrackCollection objectToSerialize)
        {
            Stream stream = File.Open(TRACK_LIST_FILENAME, FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, objectToSerialize);
            stream.Close();
        }

        public MusicTrackCollection DeSerializeObject()
        {
            try
            {
                MusicTrackCollection objectToSerialize;
                Stream stream = File.Open(TRACK_LIST_FILENAME, FileMode.Open);
                BinaryFormatter bFormatter = new BinaryFormatter();
                objectToSerialize = (MusicTrackCollection)bFormatter.Deserialize(stream);
                stream.Close();
                return objectToSerialize;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return new MusicTrackCollection();
            }
        }
    }
}