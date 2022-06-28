using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw6._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataBase dataBase = new DataBase();
            dataBase.ToWork(dataBase);
        }
    }

    class DataBase
    {
        private int _numberId = 0;
        private List<Player> _players = new List<Player>();

        public void ToWork(DataBase dataBase)
        {
            bool isWork = true;
            string userInput;

            while(isWork)
            {
                Console.SetCursorPosition(0, 20);
                dataBase.ShowInfo();

                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Меню");
                Console.WriteLine("\n1 - Добавить игрока.\n2 - найти игрока по Id.\n3 - удалить игрока\n4 - забанить игрока.\n5 - разбанить игрока.\n6 - выход");
                userInput = Console.ReadLine();

                switch(userInput)
                {
                    case "1":
                        CreatePlayer();
                        break;
                    case "2":
                        SearchId();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "3":
                        DeletePlayer();
                        break;
                    case "4":
                        Ban();
                        break;
                    case "5":
                        UnBan();
                        break;
                    case "6":
                        isWork = false;
                        break;

                }
            }
        }

        private void CreatePlayer()
        {
            Random random = new Random();

            string userInput;
            
            Console.Write("Введите имя игрока:");           
            userInput = Console.ReadLine();
            _players.Add(new Player(userInput, random));
            _players[_players.Count - 1].ShowStats();
            Console.ReadLine();
            Console.Clear();           
        }

        private void ShowInfo()
        {
            int number = 0;

            foreach (Player player in _players)
            {
                Console.Write(number + " ");
                player.ShowStats();
                number++;
            }
        }

        private void DeletePlayer()
        {
            SearchId();
            Console.WriteLine($"ID {_players[_numberId].Id} удалён.");
            _players.RemoveAt(_numberId);
            Console.ReadLine();
            Console.Clear();
        }

        private void Ban()
        {
            SearchId();
            _players[_numberId].Ban();    
            Console.ReadKey();
            Console.Clear();
        }

        private void UnBan()
        {
            SearchId();
            _players[_numberId].UnBan();   
            Console.ReadKey();
            Console.Clear();
        }

        private void SearchId()
        {
            int intermediate = 0;           
            int playerId;
            string userInput;

            Console.Write("Введите id игрока:");
            userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int result))
            {
                foreach (Player player in _players)
                {
                    playerId = player.Id;

                    if(playerId == result)
                    {
                        _numberId = intermediate;
                        break;
                    }

                    intermediate++;
                }

                _players[_numberId].ShowStats();
            }
            else
            {
                Console.WriteLine("Некорректный ввод");
                Console.ReadLine();
            }
        }
    }

    class Player
    {
        private static int _ids;
        private string _name;
        private int _level;
        private bool _banStatus;

        public Player(string name, Random random)
        {
            int maxLevel = 100;
            int minLevel = 1;
            Id = ++_ids;
            _name = name;
            _level = random.Next(minLevel, maxLevel);
            _banStatus = false;
        }

        public int Id { get; private set; }

        public void ShowStats()
        {
            string intermediate;

            if (_banStatus)
            {
                intermediate = "забанен";
            }
            else
            {
                intermediate = "не забанен";
            }

            Console.WriteLine($"Игрок: {_name} имеет id:{Id} level: {_level} Состояние на сервере: {intermediate}");
        }

        public void Ban()
        {
            _banStatus = true;
        }

        public void UnBan()
        {
            _banStatus = false;
        }
    }
}
