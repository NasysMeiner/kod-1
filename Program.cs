using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int progress = 0;
            string message = "";
            string stop = "exit";

            while (message != stop)
            {
                Console.WriteLine("Вы хотите продолжить закачку файла?");
                message = Console.ReadLine();
                progress++;
                Console.WriteLine($"Скачалось {progress}кб.");
            }
            Console.WriteLine("Вы остановили закачку фала.");
            Console.ReadLine();
        }
    }
}
