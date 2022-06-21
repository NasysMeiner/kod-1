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
            int health = 7;
            int maxHealth = 10;
            int mana = 2;
            int maxMana = 10;

            Bar(health, maxHealth, symbol:'_');
            Bar(mana, maxMana, 1, ConsoleColor.Blue, symbol:'_');

            Console.ReadLine();
        }

        static void Bar(int value, int maxValue, int PositionY = 0, ConsoleColor color = ConsoleColor.DarkRed, char symbol = ' ')
        {
            Console.Write("[");
            string bar = "";
            ConsoleColor defaultColor = Console.BackgroundColor;

            Console.SetCursorPosition(1, PositionY);
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
