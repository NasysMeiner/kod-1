using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2._8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = "password";
            string inputUser;

            Console.WriteLine("Введите пароль:");
            inputUser = Console.ReadLine();

            for (int i = 2; i > 0; i--)
            {
                if (inputUser == password)
                {
                    Console.WriteLine("Секреты");
                }
                else
                {
                    Console.WriteLine("Пароль неверный, попробуйте снова.");
                    Console.WriteLine($"Попыток осталось: {i}.");
                    inputUser = Console.ReadLine();
                }
            }
            Console.ReadLine();
        }
    }
}
