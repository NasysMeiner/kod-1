using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw4._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int healthProtsent = 70;
            int maxHealth = 100;
            int manaProtsent = 20;
            int maxMana = 100;

            Bar(healthProtsent, maxHealth, symbol:'_');
            Bar(manaProtsent, maxMana, 1, ConsoleColor.Blue, symbol:'_');

            Console.ReadLine();
        }

        static void Bar(int protsent, int maxValue, int positionY = 0, ConsoleColor color = ConsoleColor.DarkRed, char symbol = ' ')
        {
            int value = (maxValue / 100) * protsent;

            Console.Write("[");
            string bar = "";
            ConsoleColor defaultColor = Console.BackgroundColor;

            Console.SetCursorPosition(1, positionY);
            Console.BackgroundColor = color;

            for (int i = 0; i < value; i++)
            {
                bar += symbol;
            }

            Console.Write(bar);
            Console.BackgroundColor = defaultColor;
            bar = "";

            for (int i = maxValue; i > value; i--)
            {
                bar += symbol;
            }

            Console.SetCursorPosition(value, PositionY);
            Console.Write(bar);
            Console.WriteLine("]");
        }
    }
}
