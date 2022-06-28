using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw6._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Jhon", 15, 1000);
            player.ShowStats();
            Console.ReadLine();
        }
    }

    class Player
    {
        private string _name;
        private int _level;
        private int _money;

        public Player(string name, int level, int money)
        {
            _name = name;
            _level = level;
            _money = money;
        }

        public void ShowStats()
        {
            Console.WriteLine($"{_name} имеет {_level} лвл и {_money} золота.");
        }
    }
}
