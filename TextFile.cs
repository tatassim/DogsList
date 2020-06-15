using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogs
{
    class TextFile : IFileManager
    {
        public List<Dog> LoadFromFile(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName, System.Text.Encoding.UTF8))
            {
                List<Dog> list = new List<Dog>();
                while (sr.Peek() > -1)
                {
                    string breed = sr.ReadLine();
                    int age;
                    int.TryParse(sr.ReadLine(), out age);
                    string fio = sr.ReadLine();
                    Marks mark = StringToKindFromFile(sr.ReadLine());
                    sr.ReadLine();
                    Dog tmp = new Dog(breed, age, fio, mark);
                    list.Add(tmp);
                }
                sr.Close();
                return list;
            }
        }

        public void PrintToFile(List<Dog> list, string fileName)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName, false, System.Text.Encoding.UTF8))
                {
                    foreach (var item in list)
                    {
                        PrintToSW(item, sw);
                    }
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

       

        public void PrintToSW(Dog test, StreamWriter sw)
        {
            sw.WriteLine(test.Breed);
            sw.WriteLine(test.Age.ToString());
            sw.WriteLine(test.Fio);
            sw.WriteLine(test.Mark);
            sw.WriteLine();
        }

        public static Marks StringToKindFromFile(string test)
        {
            if (test == "Удовл")
            {
                return Marks.Удовл;
            }
            if (test == "Хор")
            {
                return Marks.Хор;
            }
            if (test == "Очень_хор")
            {
                return Marks.Очень_хор;
            }
            if (test == "Отл")
            {
                return Marks.Отл;
            }
            return Marks.Null;
        }

    }
}
