using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Dogs
{
    class BinaryFile : IFileManager
    {
        public List<Dog> LoadFromFile(string fileName)
        {
            using (FileStream f = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                return (List<Dog>)bf.Deserialize(f);
            }
        }

        public void PrintToFile(List<Dog> list, string fileName)
        {
            using (FileStream f = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(f, list);
                f.Close();
            }

        }
    }
}
