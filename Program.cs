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
            int playerDY = 0;
            int playerDX = 0;
            string bag = "";

            Console.CursorVisible = false;

            char[,] map = ReadMap("map", out playerY, out playerX);

            DrawMap(map, playerX, playerY);

            Console.SetCursorPosition(0, 26);
            Console.WriteLine("Сумка:" + bag);
            Console.SetCursorPosition(playerX, playerY);
            Console.WriteLine("!");

            while(isPlaying)
            {
                DrawPlayer(map ,ref playerX, ref playerY, ref playerDY, ref playerDX, ref bag);
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

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i,j]);
                }

                Console.WriteLine();
            }
        }

        static void EditVariable(char[,] map ,ref int playerX, ref int playerY, ConsoleKeyInfo move)
        {
            switch (move.Key)
            {
                case ConsoleKey.UpArrow:
                    MoveToMinusY(map ,ref playerX, ref playerY);
                    break;
                case ConsoleKey.DownArrow:
                    MoveToPlusY(map ,ref playerX, ref playerY);
                    break;
                case ConsoleKey.LeftArrow:                                        
                    MoveToMinusX(map ,ref playerX, ref playerY);                  
                    break;
                case ConsoleKey.RightArrow:
                    MoveToPlusX(map ,ref playerX, ref playerY);
                    break;
            }
        }

        static void MoveToMinusY(char[,] map, ref int playerY, ref int playerX)
        {
            if (map[playerY - 1, playerX] != '#')
            {
                playerY--;
            }
        }

        static void MoveToPlusY(char[,] map, ref int playerY, ref int playerX)
        {
            if (map[playerY + 1, playerX] != '#')
            {
                playerY++;
            }
        }

        static void MoveToMinusX(char[,] map, ref int playerY, ref int playerX)
        {
            if (map[playerY, playerX - 1] != '#')
            {
                playerX--;
            }
        }

        static void MoveToPlusX(char[,] map, ref int playerY, ref int playerX)
        {
            if (map[playerY, playerX + 1] != '#')
            {
                playerX++;
            }
        }

        static void DrawPlayer(char[,] map, ref int playerX, ref int playerY, ref int playerDY, ref int playerDX, ref string bag)
        {
            ConsoleKeyInfo move = Console.ReadKey(true);

            Console.SetCursorPosition(playerX, playerY);
            Console.WriteLine(" ");
            
            
            EditVariable(map, ref playerY, ref playerX, move);
            

            Console.SetCursorPosition(playerX, playerY);
            Console.WriteLine("!");

            if (map[playerY, playerX] == 'X')
            {
                bag += "X";
            }

            Console.SetCursorPosition(0, 26);
            Console.WriteLine("Сумка:" + bag);
        }
    }
}
