using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wh_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hour = 60;
            int allMinutes;
            int waitingHour;
            int waitingMinutes;
            int human;
            int waitingTime = 10;

            Console.Write("Сколько старушек в очереди? ");
            human = Convert.ToInt32(Console.ReadLine());

            allMinutes = human * waitingTime;
            waitingHour = allMinutes / hour;
            waitingMinutes = allMinutes - (hour * waitingHour);

            Console.Write($"Вы должны отстоять в очереди {waitingHour} часов и {waitingMinutes} минут.");
            Console.ReadLine();
        }
    }
}
