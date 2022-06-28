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

        private void NewPlayer()
        {
            Random random = new Random();
            
            Console.Write("Введите имя игрока:");           
            string userInput = Console.ReadLine();
            _players.Add(new Player(random.Next(1, 101), userInput, random));
            _players[_players.Count - 1].ShowStats();
            Console.ReadLine();
            Console.Clear();           
        }
        
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
                        dataBase.NewPlayer();
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

        private void ShowInfo()
        {
            int i = 0;

            foreach (Player player in _players)
            {
                Console.Write(i + " ");
                player.ShowStats();
                i++;
            }
        }

        private void DeletePlayer()
        {
            Console.Write("Введите id игрока:");
            string userInput = Console.ReadLine();
            int numberId = 0;
            int i = 0;

            foreach (Player player in _players)
            {
                int playerId = player.NumberId;

                if(playerId == Convert.ToInt32(userInput))
                {
                    numberId = i;
                    break;
                }

                i++;
            }

            _players.RemoveAt(numberId);
            Console.WriteLine($"ID {numberId} удалён.");
            Console.ReadLine();
            Console.Clear();
        }

        private void ToBan()
        {
            bool condition = true;
            Console.Write("Введите id игрока:");
            string userInput = Console.ReadLine();
            int numberId = 0;
            int i = 0;

            Console.WriteLine("Забанить или разбанить игрока?\n1 - забанить\n2 - разбанить");
            string value = Console.ReadLine();

            if (value == "1")
            {
                condition = false;
            }
            else if (value == "2")
            {
                condition = true;
            }

            foreach (Player player in _players)
            {
                int playerId = player.NumberId;

                if(playerId == Convert.ToInt32(userInput))
                {
                    numberId = i;
                    break;
                }

                i++;
            }

            _players[numberId].ToBan(condition);
            _players[numberId].ShowStats();
            Console.ReadLine();
            Console.Clear();
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
