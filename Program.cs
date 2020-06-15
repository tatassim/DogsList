using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogs
{
    class Program
    {
        const string path = @"C:\Users\hp\Desktop\Новая папка\Dogs\";
        static void Main(string[] args)
        {
            List<Dog> list = ConsoleHelper.InputData();
            ConsoleHelper.PrintToConsole(list);
            int responce;
            do
            {
                Console.WriteLine("Что вы хотите сделать?" +
                    "\n1 - Добавить инфо о собаке" +
                    "\n2 - Выполнить поиск собак по породе, допущенных к разведению" +
                    "\n3 - Сохранить все данные в файл" +
                    "\n4 - Редактировать данные о собаке  " +
                    "\n5 - Удалить данные о собаке  " +
                    "\n0 - Завершение работы");
                int.TryParse(Console.ReadLine(), out responce);
                switch (responce)
                {
                    case 1:
                        list = list.Concat(ConsoleHelper.InputData()).ToList();
                        ConsoleHelper.PrintToConsole(list);
                        break;
                    case 2:
                        Console.WriteLine("Будет выведена информация о собаках, которые допущены " +
                            "\nк разведению (оценка выше не ниже очень хор), заданной породы," +
                            "\n упорядоченные по возрасту");
                        Console.ReadLine();
                        List<Dog> sortedList = SortDogs(list);
                        Console.WriteLine("Количество подходящих собак: "+ sortedList.Count);
                        ConsoleHelper.PrintToConsole(sortedList);
                        break;
                    case 3:
                        string name;
                        IFileManager file = ConsoleHelper.ChooseFile(out name);
                        file.PrintToFile(list, path + name);
                        Console.WriteLine("Запись выполнена");
                        break;
                    case 4:
                        Console.ReadLine();
                        Console.WriteLine("Выберите какой элемент вы хотите редактрировать, начиная с 0");
                        int edIndex;
                        int.TryParse(Console.ReadLine(), out edIndex);
                        list.Insert(edIndex, ConsoleHelper.EditCar(list, edIndex));
                        Console.WriteLine("Редактирование завершено");
                        Console.ReadLine();
                        ConsoleHelper.PrintToConsole(list);
                        break;

                    case 5:
                        Console.ReadLine();
                        Console.WriteLine("Выберите какой элемент удалить, начиная с 0");
                        int resp;
                        int.TryParse(Console.ReadLine(), out resp);
                        list.RemoveAt(resp);
                        Console.WriteLine("Удаление завершено");
                        Console.ReadLine();
                        ConsoleHelper.PrintToConsole(list);
                        break;
                }
            }
            while (responce != 0);
        }

        static List<Dog> SortDogs(List<Dog> list)
        {
            Console.WriteLine("Введите породу");
            string breed = Console.ReadLine();
            Console.WriteLine();

            List<Dog> sortedList = list.Where(cn => cn.Breed == breed && (cn.Mark >= Marks.Очень_хор))
                                 .OrderBy(item => item.Age)
                                 .ToList();
            return sortedList;
        }
    }
}
