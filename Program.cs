using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw3._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] array = { 
                { 2, 4, 10, 8, 9, 6 ,4, 7, 5, 10 },
                { 2, 4, 10, 8, 9, 6 ,4, 7, 5, 10 },
                { 2, 4, 10, 8, 9, 6 ,4, 7, 5, 10 },
                { 2, 4, 10, 8, 9, 6 ,4, 7, 5, 10 },
                { 2, 4, 10, 8, 9, 6 ,4, 7, 5, 10 },
                { 2, 4, 10, 8, 9, 6 ,4, 7, 5, 10 },
                { 2, 4, 10, 8, 9, 6 ,4, 7, 5, 10 },
                { 2, 4, 10, 8, 9, 6 ,4, 7, 5, 10 },
                { 2, 4, 10, 8, 9, 6 ,4, 7, 5, 10 },
                { 2, 4, 10, 8, 9, 6 ,4, 7, 5, 10 }
            };

            int maxNumber = int.MinValue;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write("|" + array[i, j] + "|");
                    if (array[i, j] > maxNumber)
                    {
                        maxNumber = array[i, j];
                    }
                }
                Console.WriteLine("");
            }

            Console.WriteLine("\n");

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] == maxNumber)
                    {
                        array[i, j] = 0;
                    }
                    Console.Write("|" + array[i, j] + "|");                    
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
