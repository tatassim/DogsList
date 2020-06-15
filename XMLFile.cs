using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Dogs
{
    class XmlFIle : IFileManager
    {
        public List<Dog> LoadFromFile(string fileName)
        {
            using (XmlReader reader = XmlReader.Create(fileName))
            {
                XmlSerializer s = new XmlSerializer(typeof(List<Dog>));
                return (List<Dog>)s.Deserialize(reader);
            }
        }

        public void PrintToFile(List<Dog> list, string fileName)
        {
            using (XmlWriter writer = XmlWriter.Create(fileName))
            {
                XmlSerializer s = new XmlSerializer(typeof(List<Dog>));
                s.Serialize(writer, list);
                writer.Close();
            }

        }
    }
}
