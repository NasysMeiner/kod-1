using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hw4._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isPlaying = true;
            int playerX;
            int playerY;
            string bag = "";

            Console.CursorVisible = false;

            char[,] map = ReadMap("map", out playerY, out playerX);

            DrawMap(map, playerX, playerY);

            Console.SetCursorPosition(0, 26);
            Console.WriteLine("Сумка:" + bag);
            //Console.SetCursorPosition(24, 7);
            //Console.WriteLine("&");

            while(isPlaying)
            {
                DrawPlayer(map ,ref playerX, ref playerY, ref bag);
            }
        }

        static char[,] ReadMap(string nameMap, out int playerY, out int playerX)
        {
            playerX = 0;
            playerY = 0;

            string[] fileMap = File.ReadAllLines($"map/{nameMap}.txt"); 
            char[,] map = new char[fileMap.Length, fileMap[0].Length];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = fileMap[i][j];

                    if (map[i,j] == '@')
                    {
                        playerX = j;
                        playerY = i;
                        map[i,j] = ' ';
                    }
                }
            }

            return map;
        }

        static void DrawMap(char[,] map, int playerX, int playerY)
        {
            //Console.Clear();

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i,j]);
                }

                Console.WriteLine();
            }

            Console.SetCursorPosition(playerX, playerY);
            Console.WriteLine("!");
        }

        static void Move(char[,] map, ref int playerY, ref int playerX, ref string bag, ConsoleKeyInfo move)
        {            
            switch (move.Key)
            {
                case ConsoleKey.UpArrow:

                    if (map[playerY - 1, playerX] != '#')
                    {
                        playerY--;
                    }

                    break;

                case ConsoleKey.DownArrow:
                    
                    if (map[playerY + 1, playerX] != '#')
                    {
                        playerY++;
                    }

                    break;

                case ConsoleKey.LeftArrow:
                    
                    if (map[playerY, playerX - 1] != '#')
                    {
                        playerX--;
                    }

                    break;

                case ConsoleKey.RightArrow:
                    
                    if (map[playerY, playerX + 1] != '#')
                    {
                        playerX++;
                    }

                    break;
            }

            if (map[playerY, playerX] == 'X')
            {
                bag += "X";
            }
        }

        static void DrawPlayer(char[,] map, ref int playerX, ref int playerY, ref string bag)
        {
            ConsoleKeyInfo move = Console.ReadKey(true);

            Console.SetCursorPosition(playerX, playerY);
            Console.WriteLine(" ");

            Move(map, ref playerY, ref playerX, ref bag, move);

            Console.SetCursorPosition(playerX, playerY);
            Console.WriteLine("!");

            Console.SetCursorPosition(0, 26);
            Console.WriteLine("Сумка:" + bag);
        }
    }
}
