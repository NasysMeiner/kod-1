using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw5._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true;
            string userInput = "";

            Dictionary<string, string> dossiers = new Dictionary<string, string>();

            while (isWork)
            {
                Console.WriteLine("Выберите пункт:");
                Console.WriteLine("1 - добавить досье.\n2 - вывести все досье.\n3 - удалить досье.\n4 - выход.");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddDossier(ref dossiers);
                        break;
                    case "2":
                        ViewDossiers(dossiers);
                        break;
                    case "3":
                        DeleteDossier(dossiers);
                        break;
                    case "4":
                        isWork = false;
                        break;
                }

                Console.Clear();    
            }
        }

        static void AddDossier(ref Dictionary<string, string> dossiers)
        {
            Console.Clear();

            Console.WriteLine("Введите ФИО:");
            string key = Console.ReadLine();

            Console.WriteLine("Введите должность:");
            string value = Console.ReadLine();

            dossiers.Add(key, value);

            Console.WriteLine($"Вы добавили {key} - {value}");
            Console.ReadKey();
        }

        static void ViewDossiers(Dictionary<string, string> dossiers)
        {
            Console.Clear();

            foreach (var dossier in dossiers)
            {
                Console.WriteLine($"{dossier.Key} - {dossier.Value}");
            }

            Console.ReadLine();
        }

        static void DeleteDossier(Dictionary<string, string> dossiers)
        {
            string userInput = "";

            Console.Write("Введите ФИО в досье, которое хотите удалить.");
            userInput = Console.ReadLine();

            dossiers.Remove(userInput);
            
            Console.Clear();
        }
    }
}
