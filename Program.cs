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
            string userInput = "";

            while(isWork)
            {
                Console.SetCursorPosition(0, 20);
                dataBase.ShowInfo();

                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Меню");
                Console.WriteLine("\n1 - Добавить игрока.\n2 - удалить игрока.\n3 - забанить или разбанить игрока.\n4 - выход.");
                userInput = Console.ReadLine();

                switch(userInput)
                {
                    case "1":
                        dataBase.CreatePlayer();
                        break;
                    case "2":
                        dataBase.DeletePlayer();
                        break;
                    case "3":
                        dataBase.ToBan();
                        break;
                    case "4":
                        isWork = false;
                        break;

                }
            }
        }

        private void CreatePlayer()
        {
            Random random = new Random();

            string userInput = "";
            
            Console.Write("Введите имя игрока:");           
            userInput = Console.ReadLine();
            _players.Add(new Player(random.Next(1, 101), userInput, random));
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
            string userInput = "";
            int numberId = 0;
            int playerId = 0;

            Console.Write("Введите id игрока:");
            userInput = Console.ReadLine();

            numberId = TryPlayerIndex(userInput);

            _players.RemoveAt(numberId);
            Console.WriteLine($"ID {numberId} удалён.");
            Console.ReadLine();
            Console.Clear();
        }

        private void ToBan()
        {
            bool condition = true;
            string userInput = "";
            string value = "";
            int numberId = 0;
            int playerId = 0;
            int result = 0;

            Console.Write("Введите id игрока:");
            userInput = Console.ReadLine();

            Console.WriteLine("Забанить или разбанить игрока?\n1 - забанить\n2 - разбанить");
            value = Console.ReadLine();

            if (int.TryParse(userInput, out result))
            {
                if (value == "1")
                {
                    condition = false;
                }
                else if (value == "2")
                {
                    condition = true;
                }

                numberId = TryPlayerIndex(userInput);

                _players[numberId].ToBan(condition);
                _players[numberId].ShowStats();
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Некорректный ввод.");
            }
        }

        private int TryPlayerIndex(string userInput)
        {
            int intermediate = 0;
            int playerId = 0;
            int numberId = 0;

            foreach (Player player in _players)
            {
                playerId = player.NumberId;

                if(playerId == Convert.ToInt32(userInput))
                {
                    numberId = intermediate;
                    break;
                }

                intermediate++;
            }

            return numberId;
        }
    }

    class Player
    {
        private int _numberId;
        private string _name;
        private int _level;
        private bool _flag;

        public Player(int numberId, string name, Random random)
        {
            
            _numberId = numberId;
            _name = name;
            _level = random.Next(1, 10);
            _flag = true;
        }

        public int NumberId
        {
            get { return _numberId; }
        }

        public void ShowStats()
        {
            string intermediate = "";

            if (_flag)
            {
                intermediate = "не забанен";
            }
            else
            {
                intermediate = "забанен";
            }

            Console.WriteLine($"Игрок: {_name} имеет id:{_numberId} level: {_level} Состояние на сервере: {intermediate}");
        }

        public void ToBan(bool ban)
        {
            if (_flag == ban && ban == false)
            {
                Console.WriteLine("Игрок уже забанен.");
            }
            else if (_flag == ban && ban == true)
            {
                Console.WriteLine("Игрок и так разбанен.");
            }
            else
            {
                _flag = ban;
            }
        }
    }
}
