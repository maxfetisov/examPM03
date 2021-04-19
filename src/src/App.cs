using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src
{
    public class App
    {
        private string name;
        private string producer;
        private double price;

        public string Name { get => name; set => name = value; }
        public string Producer { get => producer; set => producer = value; }
        public double Price { get => price; set => price = value; }

        public App() { }
        public App(string name, string producer, double price)
        {
            this.name = name;
            this.producer = producer;
            this.price = price;
        }

        public override string ToString() => $"{name}, {producer}, {price}";
    }
}
