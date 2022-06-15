using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wh_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "Иванович";
            string surname ="Иван";
            string intermediate;

            Console.WriteLine($"Имя: {name}, фамилия: {surname}");

            intermediate = name;
            name = surname;
            surname = intermediate;

            Console.WriteLine($"Имя: {name}, фамилия: {surname}");
            Console.ReadLine();

            
        }
    }
}
