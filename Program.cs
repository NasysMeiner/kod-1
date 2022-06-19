using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw3._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 10, 9, 8, 4, 6, 7, 5, 2, 1, 3 };
            int a = 0;

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("|" + array[i] + "|");
            }

            Console.WriteLine();

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[i] < array[j])
                    {
                        a = array[j];
                        int b = array[i];
                        array[j] = array[i];
                        array[i] = a;
                    }
                }
            }
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("|" + array[i] + "|");
            }
            Console.ReadLine();
        }
    }
}
