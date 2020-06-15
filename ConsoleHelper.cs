using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogs
{
    public class ConsoleHelper
    {
        const string path = @"C:\Users\hp\Desktop\Новая папка\Dogs\"; //ввести путь с константой!!!!
        public static void PrintToConsole(List<Dog> list)
        {
            int i = 0;
            foreach (var item in list)
            {
                Console.Write(String.Format("{0} - ", i));
                Console.WriteLine(item.ToString());
                i++;
            }
            Console.WriteLine(String.Format("Количество записей о собаках : {0}", i));
            Console.ReadLine();
            Console.WriteLine();
        }


        public static List<Dog> InputData()
        {
            Console.WriteLine("Что вы хотите сделать? " +
                "\n1 - Ввести данные о собаках с консоли, " +
                "\n2 - Открыть файл");
            int response;
            int.TryParse(Console.ReadLine(), out response);
            switch (response)
            {
                case 1:
                    return InputDataFromConsole();
                case 2:
                    string name;
                    return ChooseFile(out name).LoadFromFile(path + name);
                default:
                    throw new Exception("Введены неверные данные");
            }
        }

        public static List<Dog> InputDataFromConsole()
        {
            int response;
            List<Dog> list = new List<Dog>();
            do
            {
                Console.WriteLine("Введите информацию о собаке");
                list.Add(SetDog());
                Console.WriteLine("Если хотите добавить еще одну собаку - нажмите любую клавишу, для отмены ввода нажмите 0");
                int.TryParse(Console.ReadLine(), out response);
            }
            while (response != 0);
            return list;
        }

        public static Dog SetDog()
        {
            Console.WriteLine("Введите породу");
            string breed = Console.ReadLine();

            Console.WriteLine("Введите возраст");
            int age;
            int.TryParse(Console.ReadLine(), out age);

            Console.WriteLine("Введите ФИО");
            string fio = Console.ReadLine();

            Console.WriteLine("Введите оценку");
            Console.WriteLine("Введите число 1-Удовл, 2 - Хор, 3 - Очень хор, 4 - Отл ");
            Marks mark = StringToKind(Console.ReadLine());

            Console.ReadLine();

            Dog tmp = new Dog(breed, age, fio, mark);
            return tmp;
        }

        public static Dog EditCar(List<Dog> list, int resp)
        {
            list.RemoveAt(resp);

            Console.WriteLine("Введите породу");
            string breed = Console.ReadLine();

            Console.WriteLine("Введите возраст");
            int age;
            int.TryParse(Console.ReadLine(), out age);

            Console.WriteLine("Введите ФИО");
            string fio = Console.ReadLine();

            Console.WriteLine("Введите оценку");
            Console.WriteLine("Введите число 1-Удовл, 2 - Хор, 3 - Очень хор, 4 - Отл ");
            Marks mark = StringToKind(Console.ReadLine());

            Console.ReadLine();

            Dog tmp = new Dog(breed, age, fio, mark);
            return tmp;
        }

        public static IFileManager ChooseFile(out string fName)
        {
            Console.WriteLine("Введите имя файла: ");
            string responce = Console.ReadLine();
            fName = responce;
            if (File.Exists(path + fName))
            {
                return FileFabric.GetFile(Path.GetExtension(responce));
            }
            else
            {
                FileStream file1 = new FileStream(path + fName, FileMode.Create);
                file1.Close();
                return FileFabric.GetFile(Path.GetExtension(responce));
            } 

        }

        public static string KindToString(Marks kind)
        {
            if (kind == Marks.Удовл)
            {
                return "Удовл";
            }
            if (kind == Marks.Хор)
            {
                return "Хор";
            }
            if (kind == Marks.Очень_хор)
            {
                return "Очень_хор";
            }
            if (kind == Marks.Отл)
            {
                return "Отл";
            }
            return "Неизвестно";
        }

        public static Marks StringToKind(string kind)
        {
            int test;
            if (Int32.TryParse(kind, out test))
            {
                switch (test)
                {
                    case 1:
                        return Marks.Удовл;
                    case 2:
                        return Marks.Хор;
                    case 3:
                        return Marks.Очень_хор;
                    case 4:
                        return Marks.Отл;
                    default:
                        throw new Exception("Данные о такой оценке не найдены");
                }
            }
            else
            {
                throw new Exception("Введено не число!");
            }
        }
    }    
}
