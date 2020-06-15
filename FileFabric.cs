using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogs
{
    static public class FileFabric
    {
        public static IFileManager GetFile(string exstension)
        {
            IFileManager file;
            switch (exstension)
            {
                case ".txt":
                    file = new TextFile();
                    break;
                case ".bin":
                    file = new BinaryFile();
                    break;
                case ".xml":
                    file = new XmlFIle();
                    break;
                default: throw new NotSupportedException("Файл данного типа не поддерживается");
            }
            return file;
        }


    }
}
