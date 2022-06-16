using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "";
            string userInput = "0";
            string userPassword = "";
            string password = "123";
            string userColor = "0";
            while (Convert.ToInt32(userInput) < 5)
            {
                Console.WriteLine("Выберите функцию:");
                Console.WriteLine("1 - установить имя.");
                Console.WriteLine("2 - установить пароль.");
                Console.WriteLine("3 - вывод информации.");
                Console.WriteLine("4 - изменить цвет текста.");
                Console.WriteLine("5 - закрыть программу.");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.Write("Ваше имя: ");
                        name = Console.ReadLine();
                        break;
                    case "2":
                        Console.Write("Установите пароль: ");
                        password = Console.ReadLine();
                        break;
                    case "3":
                        Console.WriteLine("Введите пароль");
                        userPassword = Console.ReadLine();

                        if(userPassword == password)
                        {
                            Console.WriteLine($"Вас зовут: {name}.");
                        }
                        else
                        {
                            Console.WriteLine("Пароль неверный.");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Какой цвет текста вы хотите?.");
                        Console.WriteLine("1 - зелёный.");
                        Console.WriteLine("3 - синий.");
                        Console.WriteLine("3 - пурпурный.");
                        Console.WriteLine("4 - оставить как есть.");

                        userColor = Console.ReadLine();

                        switch (userColor)
                        {
                            case "1":
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            case "2":
                                Console.ForegroundColor = ConsoleColor.Blue;
                                break;
                            case "3":
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                break;
                            case "4":
                                break;
                        }

                        break;                    
                }

            }
        }
    }
}
