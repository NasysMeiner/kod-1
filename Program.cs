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
                Console.WriteLine("\n1 - Добавить игрока.\n2 - найти игрока по Id.\n3 - выход");
                userInput = Console.ReadLine();

                switch(userInput)
                {
                    case "1":
                        dataBase.CreatePlayer();
                        break;
                    case "2":
                        dataBase.SearchId();
                        break;
                    case "3":
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

        private void DeletePlayer(int numberId)
        {
                Console.WriteLine($"ID {_players[numberId].IdPlayer} удалён.");
                _players.RemoveAt(numberId);
                Console.ReadLine();
                Console.Clear();
        }

        private void Ban(int numberId)
        {
            bool condition = false;
            _players[numberId].condition(condition);
            _players[numberId].ShowStats();
            Console.ReadLine();
            Console.Clear();                    
        }

        private void UnBan(int numberId)
        {
            bool condition = true;
            _players[numberId].condition(condition);
            _players[numberId].ShowStats();
            Console.ReadLine();
            Console.Clear();                    
        }

        private void SearchId()
        {
            int intermediate = 0;
            int numberId = 0;
            int playerId;
            string userInput;

            Console.Write("Введите id игрока:");
            userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int result))
            {
                foreach (Player player in _players)
                {
                    playerId = player.IdPlayer;

                    if(playerId == Convert.ToInt32(userInput))
                    {
                        numberId = intermediate;
                        break;
                    }

                    intermediate++;
                }

                EditPlayer(numberId);
            }
            else
            {
                Console.WriteLine("Некорректный ввод");
                Console.ReadLine();
                Console.Clear();
            }
        }

        private void EditPlayer(int numberId)
        {
            string userInput;

            Console.WriteLine("Меню");
            Console.WriteLine("\n1 - удалить игрока.\n2 - забанить игрока.\n3 - разбанить игрока");
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    DeletePlayer(numberId);
                    break;
                case "2":
                    Ban(numberId);
                    break;
                case "3":
                    UnBan(numberId);
                    break;
            }
        }
    }

    class Player
    {
        private static int _ids;
        private int _numberId;
        private string _name;
        private int _level;
        private bool _stateOnTheServer;

        public Player(string name, Random random)
        {
            int maxLevel = 100;
            int minLevel = 1;
            _numberId = ++_ids;
            _name = name;
            _level = random.Next(minLevel, maxLevel);
            _stateOnTheServer = true;
        }

        public int IdPlayer
        {
            get { return _numberId; }
        }

        public void ShowStats()
        {
            string intermediate;

            if (_stateOnTheServer)
            {
                intermediate = "не забанен";
            }
            else
            {
                intermediate = "забанен";
            }

            Console.WriteLine($"Игрок: {_name} имеет id:{_numberId} level: {_level} Состояние на сервере: {intermediate}");
        }

        public void condition(bool ban)
        {
            if (_stateOnTheServer == ban && ban == false)
            {
                Console.WriteLine("Игрок уже забанен.");
            }
            else if (_stateOnTheServer == ban && ban == true)
            {
                Console.WriteLine("Игрок и так разбанен.");
            }
            else
            {
                _stateOnTheServer = ban;
            }
        }
    }
}
