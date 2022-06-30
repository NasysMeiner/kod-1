﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw6._6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Salesman salesman = new Salesman(0);
            Player player = new Player(100000);
            Console.CursorVisible = false;
            bool isWork = true;
            int variable = 1;
            string userInput;

            while (isWork)
            {
                Console.SetCursorPosition(0, 25);
                Console.WriteLine($"Денег:{player.Money}.");
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Меню магазина:");
                Console.WriteLine("\n1 - показать весь товар.\n2 - купить товар.\n3 - посмотреть свой инвентарь.\n4 - выйти из магазина.\n");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        salesman.ShowAllProduct();
                        break;
                    case "2":
                        player.BuyOperation(salesman, player);
                        break;
                    case "3":
                        player.ShowAllProduct();
                        break;
                    case "4":
                        isWork = false;
                        break;
                }
            }
        }
    }

    class Human
    {
        private protected List<Product> Inventory = new List<Product>();
        public int Money { get; private set; }

        public Human(int money)
        {
            Money = money;
        }

        public void ShowAllProduct()
        {
            if(Inventory.Count > 0)
            {
                foreach (Product subject in Inventory)
                {
                    Console.WriteLine($"Товар под ID:{subject.Id} имеет название: {subject.Name} и стоит:{subject.Price}.");
                }
            }
            else
            {
                Console.WriteLine("Пусто.");
            }

            Console.ReadLine();
            Console.Clear();
        }

        private protected void TransferMoney(Salesman salesman, Player player, List<Product> inventory)
        {
            int price = inventory[inventory.Count - 1].Price;
            player.Money -= price;
            salesman.Money += price;
        }

        private protected Product DeleteProduct(Salesman salesman, int productId)
        {
            Product product;
            product = salesman.Inventory[productId];
            salesman.Inventory.RemoveAt(productId);
            return product;
        }
    }

    class Player : Human
    {
        public Player (int money) : base(money) { }

        public void BuyOperation(Salesman salesman, Player player)
        {
            string userInput;
            int idProduct;

            Console.Write("Введите Id товара, которое хотите приобрести.");
            userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int result))
            {
                idProduct = salesman.SerachIdProduct(result);

                if (idProduct >= 0)
                {
                    if (salesman.ExaminationPrice(player, idProduct))
                    {  
                        Inventory.Add(player.DeleteProduct(salesman, idProduct));
                        TransferMoney(salesman, player, Inventory);
                        Console.WriteLine("Товар куплен.");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно средств.");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("Такого товара нет.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод.");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }

    class Salesman : Human
    {
        public Salesman(int money) : base(money)
        {
            Inventory.Add(new Product("Яблоко", 100));
            Inventory.Add(new Product("Груша", 90));
            Inventory.Add(new Product("Виноград", 150));
            Inventory.Add(new Product("Арбуз", 300));
            Inventory.Add(new Product("Топор", 1100));
            Inventory.Add(new Product("Меч", 1000));
            Inventory.Add(new Product("Зелье", 40));
            Inventory.Add(new Product("Сапоги", 500));
            Inventory.Add(new Product("Лопата", 100000));
        }

        public int SerachIdProduct(int userInput)
        {
            int intermediateId = 0;
            int idProduct = -1;

            foreach (var product in Inventory)
            {
                if (product.Id == userInput)
                {
                    idProduct = intermediateId;
                }

                intermediateId++;
            }

            return idProduct;
        }

        public bool ExaminationPrice(Player player, int productId)
        {
            return Inventory[productId].Price <= player.Money;
        }
    }

    class Product
    {
        private static int _ids = 100;

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Price{ get; private set; }

        public Product(string name, int price)
        {
            Name = name;
            Price = price;
            Id = ++_ids;
        }
    }
}
