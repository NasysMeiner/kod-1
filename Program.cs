using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw6._9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CashBox cashBox = new CashBox(0);
            cashBox.BuyOperations();
        }
    }

    class CashBox
    {
        public int Money { get; private set; }

        public CashBox(int money)
        {
            Money = money;
        }

        public void BuyOperations()
        {
            Random random = new Random();
            Queue<Client> clients = new Queue<Client>();
            clients.Enqueue(new Client(10000));
            clients.Enqueue(new Client(100000));
            clients.Enqueue(new Client(5000));
            clients.Enqueue(new Client(2500));

            foreach (Client client in clients)
            {
                client.FillBasket();
            }

            while(clients.Count > 0)
            {
                Console.WriteLine($"Клиентов в очереди: {clients.Count}. Заработано: {Money}");
                Client client = clients.Dequeue();
                Console.Write("\nТекущий клиент:");   
                client.ShowInfo();
                Console.ReadKey();
                Console.Clear();

                Money += client.Pay(random);
                Console.ReadLine();
                Console.Clear();
            }    

            Console.WriteLine($"Очередь закончилась. Денег заработано: {Money}.");
            Console.ReadLine();
        }
    }

    class Client
    {
        private List<Product> _products = new List<Product>();

        public int Money { get; private set; }

        public Client(int money)
        {
            Money = money;
        }

        public void FillBasket()
        {
            _products.Add(new Product("Лопата", 100000));
            _products.Add(new Product("Стол", 5000));
            _products.Add(new Product("Яьлоко", 360));
            _products.Add(new Product("Груша", 500));
            _products.Add(new Product("Сапоги", 1500));
            _products.Add(new Product("Меч", 3000));
        }

        public void ShowInfo()
        {
            int sum = 0;

            Console.WriteLine($"{Money} money.");
            Console.WriteLine("Продукты в корзине: ");

            for(int i = 0; i < _products.Count; i++)
            {
                Console.WriteLine($"|{_products[i].Name} стоймостью - {_products[i].Price}|");
                sum += _products[i].Price;
            }

            Console.WriteLine($"\nДля оплаты требуется: {sum}");
        }

        public int Pay(Random random)
        {
            bool isWork = true;
            int amountPayable = 0;
            int productId = 0;

            while(isWork)
            {
                for(int i = 0; i < _products.Count; i++)
                {                   
                    amountPayable += _products[i].Price;
                }

                if(amountPayable <= Money)
                {
                    isWork = false;
                }
                else if(_products.Count > 0)
                {
                    amountPayable = 0;
                    _products.RemoveAt(random.Next(0, _products.Count));
                    Console.WriteLine($"Товар удалён.");
                    Console.ReadKey();
                }
                else
                {
                    isWork = false;                   
                }
            }

            if(amountPayable > 0)
            {
                ShowInfo();
                Money -= amountPayable;
                Console.WriteLine("Оплата прошла успешно.");

                return amountPayable;
            }
            else
            {
                Console.WriteLine("Клиент ушёл.");

                return 0;
            }         
        }
    }

    class Product
    {
        public string Name { get; private set; }
        public int Price { get; private set; }

        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
}
