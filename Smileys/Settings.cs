using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Smileys
{
    public class Settings
    {
        public int size = 30;
        public bool alwaysOnTop = true;
        public Size windowsSize;

        public static void Serialize(Settings settings, string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            using (TextWriter writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, settings);
            }
        }

        public static Settings Deserialize(string path)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(Settings));
            Settings settings;
            using (TextReader reader = new StreamReader(path))
            {
                try
                {
                    object obj = deserializer.Deserialize(reader);
                    settings = (Settings)obj;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            
            return settings;
        }
    }
}
