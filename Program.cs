using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2._12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int healPointMage = 1000;
            int damageMage = 100;
            int damageSpirit = 20;

            int healPointMonster = 1000;
            int damageMonster = 150;

            int spiritCost = 100;
            int damageBuff1 = 50;
            int damageBuff2 = 100;

            int unworthyHealth = 0;
            int healing = 250;
            int healPointsMax = 1000;

            int intermediate = 0;

            string userInput;

            while(healPointMage > 0 && healPointMonster > 0)
            {

                Console.WriteLine("Выберите заклинание:");
                Console.WriteLine("1 - Рашамон");
                Console.WriteLine("2 - Хуганзакура");
                Console.WriteLine("3 - Межпространственный разлом");
                Console.WriteLine("4 - Межпространственное усиление (Становится доступным после действия Межпространственного разлома.)");
                Console.WriteLine($"Здоровье мага: {healPointMage} и урон: {damageMage}. Здоровье монстра: {healPointMonster} и урон: {damageMonster}.");

                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine($"Вы призвали духа, который усиляет вашу атаку на {damageBuff1}, но отнял {spiritCost}хп.");
                        healPointMage -= spiritCost;
                        damageMage += damageBuff1;
                        healPointMage -= damageMonster;
                        break;
                    case "2":
                        Console.WriteLine("Вы атакуете вместе с духом.");
                        healPointMonster -= damageMage + damageSpirit;
                        healPointMage -= damageMonster;
                        break;
                    case "3":
                        Console.WriteLine($"Вы скрылись в межпространственном портале и восстановили себе {healing}хп.");
                        if (healPointMage < healPointsMax)
                        {
                            unworthyHealth = healPointsMax - healPointMage;

                            if (unworthyHealth < healing)
                            {
                                healPointMage += unworthyHealth;
                            }
                            else
                            {
                                healPointMage += healing;
                            }
                        }
                        intermediate++;
                        break;
                    case "4":
                        if (intermediate > 0)
                        {
                            Console.WriteLine($"Вы усиляете себя и духа на {damageBuff2} единиц урона.");
                            damageMage += damageBuff2;
                            damageSpirit += damageBuff2;
                            healPointMage -= damageMonster;
                            intermediate--;
                        }
                        else
                        {
                            Console.WriteLine("Усиление недоступно");
                        }
                        break;
                }
            }
            if (healPointMonster <= 0)
            {
                Console.WriteLine("Победил маг.");
            }
            else if (healPointMage <= 0)
            {
                Console.WriteLine("Победил монстр");
            }
            Console.ReadLine();
        }
    }
}
