using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wh_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int crystalPrice = 100;
            int gold;
            int numberOfCrystals;
            int collectCrystals;

            Console.Write("Сколько у вас золота? ");
            gold = Convert.ToInt32(Console.ReadLine());

            Console.Write("Сколько требуется кристаллов? ");
            numberOfCrystals = Convert.ToInt32(Console.ReadLine());

            collectCrystals = gold / crystalPrice;
            gold -= collectCrystals * crystalPrice;

            Console.Write($"Кристаллов купленно: {collectCrystals}, осталось золота: {gold}.");
            Console.ReadLine();
        }
    }
}
