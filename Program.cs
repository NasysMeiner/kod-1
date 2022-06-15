using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int phots = 52;
            int capacityRows = 3;
            int fullRows = phots / capacityRows;
            int remainder = phots % capacityRows;

            Console.WriteLine($"Полностью заполненных рядов: {fullRows}, а оставшихся картинок: {remainder}");
            Console.ReadLine();

        }
    }
}
