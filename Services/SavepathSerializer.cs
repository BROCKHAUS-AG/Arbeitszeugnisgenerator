using System;
using System.IO;
using System.Xml.Serialization;

namespace Brockhaus.PraktikumZeugnisGenerator.Services
{
    [Serializable]
    public class SavepathSerializer
    {
        private static SavepathSerializer savepathSerializer;
        public string SavePath;

        public static SavepathSerializer Instance
        {
            get
            {
                if (savepathSerializer == null)
                {
                    savepathSerializer = LoadSavePath();
                    if (savepathSerializer == null)
                    {
                        savepathSerializer = new SavepathSerializer();
                    }
                }
                return savepathSerializer;
            }
        }


        private SavepathSerializer()
        {
            SavePath = "";
        }


        public static SavepathSerializer LoadSavePath()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SavepathSerializer));
            SavepathSerializer loadedSavepath = null;
            try
            {
                using (Stream filestream = new FileStream(@"Files\\SavePath.xml", FileMode.Open))
                {
                    loadedSavepath = (SavepathSerializer)serializer.Deserialize(filestream);
                }
            }
            catch (FileNotFoundException)
            {
                return null;
            }

            return loadedSavepath;
        }

        public void SaveSavepath(string newSavePath)
        {
            SavePath = newSavePath;
            XmlSerializer serializer = new XmlSerializer(typeof(SavepathSerializer));
            using (Stream filestream = new FileStream(@"Files\\SavePath.xml", FileMode.Create))
            {
                serializer.Serialize(filestream, this);
            }

        }

    }
}
