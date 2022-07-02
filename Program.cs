using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw6._12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Zoo zoo = new Zoo();
            zoo.Work();
        }
    }

    class Zoo
    {
        private List<Aviary> _aviaris = new List<Aviary>();

        public Zoo()
        {
            _aviaris.Add(new Aviary("Львы", "Р", "Мужской", 2));
            _aviaris.Add(new Aviary("Кошки", "Мяу", "Женский", 10));
            _aviaris.Add(new Aviary("Обезьяны", "У", "Мужской", 14));
            _aviaris.Add(new Aviary("Волки", "Ууу", "Мужской", 8));
        }

        public void Work()
        {
            bool isWork = true;
            string userInput;

            while (isWork)
            {
                ShowAllInfo();
                Console.Write("\nПодойти к клетке номер: ");
                userInput = Console.ReadLine();

                if(int.TryParse(userInput, out int result) && result <= _aviaris.Count)
                {
                    ShowInfo(result - 1);
                }
                else
                {
                    Console.WriteLine("Некорректный ввод.");
                    Console.ReadKey();                   
                }

                Console.Clear();
            }
        }

        public void ShowAllInfo()
        {
            int numberAviary = 1;

            foreach(Aviary aviary in _aviaris)
            {
                Console.WriteLine($"Клетка - {numberAviary}: {aviary.Name}.");
                numberAviary++;
            }
        }

        public void ShowInfo(int number)
        {
            Console.Clear();
            Console.WriteLine($"В клетке: {_aviaris[number].Name}.\nВнутри {_aviaris[number].Amount} животных.\nОни издают звук {_aviaris[number].Sound}.\nИх пол {_aviaris[number].Gender}.\n");
            Console.WriteLine("\nНажмите, чтобы отойти от клетки.");
            Console.ReadKey();
        }


    }

    class Aviary
    {
        public string Name { get; private set; }
        public string Sound { get; private set; }
        public string Gender { get; private set; }
        public int Amount { get; private set; }

        public Aviary(string name, string sound, string gender, int amount)
        {
            Name = name;
            Sound = sound;
            Gender = gender;
            Amount = amount;
        }
    }
}
