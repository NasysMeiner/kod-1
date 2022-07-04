using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw7._5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Box box = new Box();
            box.Work();
        }
    }

    class Box
    {
        private List<Product> _products = new List<Product>();
        private static int _years = 2000;

        public Box()
        {
            _products.Add(new Product("Тушенка1", 15, 1989));
            _products.Add(new Product("Тушенка2", 15, 1995));
            _products.Add(new Product("Тушенка3", 15, 2000));
            _products.Add(new Product("Тушенка4", 15, 1976));
            _products.Add(new Product("Тушенка5", 15, 1958));
            _products.Add(new Product("Тушенка6", 15, 1989));
            _products.Add(new Product("Тушенка7", 15, 1970));
            _products.Add(new Product("Тушенка8", 15, 1990));
            _products.Add(new Product("Тушенка9", 15, 1991));
        }

        public void Work()
        {
            FindDelay();
            Console.ReadLine();
        }

        private void FindDelay()
        {
            var delay = _products.Where(product => (_years - product.ManufactureDate) >= product.ExpirationDate);

            foreach(var product in delay)
            {
                Console.WriteLine($"Просрочена: {product.Name}.");
            }
        }
    }

    class Product
    {
        public string Name { get; private set; }
        public int ExpirationDate { get; private set; }
        public int ManufactureDate { get; private set; }

        public Product(string name, int expirationDate, int manufactureDate)
        {
            Name = name;
            ExpirationDate = expirationDate;
            ManufactureDate = manufactureDate;
        }
    }
}
