using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogs
{
    public interface IFileManager
    {
        void PrintToFile(List<Dog> list, string fileName);
        List<Dog> LoadFromFile(string fileName);
        
    }
}
