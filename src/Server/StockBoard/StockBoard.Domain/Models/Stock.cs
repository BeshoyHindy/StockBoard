using System;
using StockBoard.Domain.Core.Models;

namespace StockBoard.Domain.Models
{
    public class Stock : Entity
    {
        public Stock(Guid id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
        // Empty constructor for EF
        public Stock() { }
        public string Name { get; private set; }
        public double Price { get; private set; }
    }
}