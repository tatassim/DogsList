using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogs
{
    [Serializable]
    public enum Marks { Удовл = 1, Хор, Очень_хор, Отл, Null = -1 };

    [Serializable]
    public class Dog
    {
        private string breed;
        private int age;
        private string fio;
        private Marks mark;

        public string Breed
        {
            get
            {
                return breed;
            }
            set
            {
                if (value != "")
                {
                    breed = value;
                }
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (age >= 0)
                {
                    age = value;
                }
            }
        }

        public string Fio
        {
            get
            {
                return fio;
            }
            set
            {
                if (value != "")
                {
                    fio = value;
                }
            }
        }

        public Marks Mark
        {
            get
            {
                return mark;
            }
            set
            {
                mark = value;
            }
        }

        public Dog()
        {
            Breed = "Deault";
            Age = 0;
            Fio = "Default";
            Mark = Marks.Null;
        }

        public Dog(string breed, int age,string fio, Marks mark)
        {
            this.Breed = breed;
            this.Age = age;
            this.Fio = fio;
            this.Mark = mark;
        }

        public override string ToString()
        {
            return String.Format("Порода: {0}, Возраст: {1}, ФИО: {2}, Оценка: {3}",
                Breed, Age.ToString(), Fio, ConsoleHelper.KindToString(Mark)); 
        }

    }
}
