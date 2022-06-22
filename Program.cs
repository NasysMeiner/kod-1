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
            int playerPositionX;
            int playerPositionY;
            string bag = "";

            Console.CursorVisible = false;

            char[,] map = ReadMap("map", out playerPositionY, out playerPositionX);

            DrawMap(map);

            Console.SetCursorPosition(0, 26);
            Console.WriteLine("Сумка:" + bag);
            Console.SetCursorPosition(playerPositionX, playerPositionY);
            Console.WriteLine("!");

            while(isPlaying)
            {
                DrawPlayer(map ,ref playerPositionX, ref playerPositionY, ref bag);
            }
        }

        static char[,] ReadMap(string nameMap, out int playerPositionY, out int playerPositionX)
        {
            playerPositionX = 0;
            playerPositionY = 0;

            string[] fileMap = File.ReadAllLines($"map/{nameMap}.txt"); 
            char[,] map = new char[fileMap.Length, fileMap[0].Length];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = fileMap[i][j];

                    if (map[i,j] == '@')
                    {
                        playerPositionX = j;
                        playerPositionY = i;
                        map[i,j] = ' ';
                    }
                }
            }

            return map;
        }

        static void DrawMap(char[,] map)
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

        static void EditVariable(char[,] map ,ref int playerPositionX, ref int playerPositionY, ConsoleKeyInfo move)
        {
            int positionY = 0;
            int positionX = 0;

            switch (move.Key)
            {
                case ConsoleKey.UpArrow:
                    positionY = -1;
                    ChangePosition(map ,ref playerPositionX, ref playerPositionY, positionY, positionX);                   
                    break;
                case ConsoleKey.DownArrow:
                    positionY = 1;
                    ChangePosition(map ,ref playerPositionX, ref playerPositionY, positionY, positionX);
                    break;
                case ConsoleKey.LeftArrow:    
                    positionX = -1;
                    ChangePosition(map ,ref playerPositionX, ref playerPositionY, positionY, positionX);                  
                    break;
                case ConsoleKey.RightArrow:
                    positionX = 1;
                    ChangePosition(map ,ref playerPositionX, ref playerPositionY, positionY, positionX);
                    break;
            }
        }

        static void ChangePosition(char[,] map, ref int playerPositionY, ref int playerPositionX, int positionY, int positionX)
        {
            if (map[playerPositionY + positionY, playerPositionX + positionX] != '#')
            {
                playerPositionX += positionX;
                playerPositionY += positionY;
            }
        }

        static void DrawPlayer(char[,] map, ref int playerPositionX, ref int playerPositionY, ref string bag)
        {
            ConsoleKeyInfo move = Console.ReadKey(true);

            Console.SetCursorPosition(playerPositionX, playerPositionY);
            Console.WriteLine(" ");
            
            
            EditVariable(map, ref playerPositionY, ref playerPositionX, move);
            

            Console.SetCursorPosition(playerPositionX, playerPositionY);
            Console.WriteLine("!");

            if (map[playerPositionY, playerPositionX] == 'X')
            {
                map[playerPositionY, playerPositionX] = ' ';
                bag += "X";
            }

            Console.SetCursorPosition(0, 26);
            Console.WriteLine("Сумка:" + bag);
        }
    }
}
