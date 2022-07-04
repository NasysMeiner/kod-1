using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw7._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Database database = new Database();
            database.Work();
        }
    }

    class Database
    {
        private List<Player> _players = new List<Player>();
        private List<Player> _playersTopStrenght = new List<Player>();

        public Database()
        {
            _players.Add(new Player("Oleg", 100000, 500));
            _players.Add(new Player("Андрей", 5000, 50));
            _players.Add(new Player("Эдик", 100, 3000));
            _players.Add(new Player("Владик", 298, 80));
            _players.Add(new Player("Nikita", 7256, 5000));
            _players.Add(new Player("Ilya", 1753, 268));
            _players.Add(new Player("Valeriy", 234556, 1000));
            _players.Add(new Player("Юрий", 4562, 347));
            _players.Add(new Player("Паша", 35678, 400));
            _players.Add(new Player("Олег", 753, 100000));
        }

        public void Work()
        {
            SortPlayerStrenght();
            SortPlayerLevel();
            Console.ReadLine();
        }

        private void SortPlayerStrenght()
        {
            int topPlayerStrenght = 3;

            var sortPlayers = _players.OrderByDescending(player => player.Strength).Take(topPlayerStrenght);

            Console.WriteLine("\nТоп 3 игрока по силе:\n");

            foreach(var player in sortPlayers)
            {
                Console.WriteLine($"{player.Name} - {player.Strength} силы и {player.Level} лвл.");
            }
        }

        private void SortPlayerLevel()
        {
            int topPlayerLevel = 3;
            int positionY = 3;

            var sortPlayers = _players.OrderByDescending(player => player.Level).Take(topPlayerLevel);

            Console.SetCursorPosition(80, 1);

            Console.WriteLine("Топ 3 игрока по лвл:\n");

            foreach (var player in sortPlayers)
            {
                Console.SetCursorPosition(80, positionY);
                Console.WriteLine($"{player.Name} - {player.Level} лвл и {player.Strength} силы.");
                positionY++;
            }
        }
    }

    class Player
    {
        public string Name { get; private set; }
        public int Strength { get; private set; }
        public int Level { get; private set; }

        public Player(string name, int strenght, int level)
        {
            Name = name;
            Strength = strenght;
            Level = level;
        }
    }
}
