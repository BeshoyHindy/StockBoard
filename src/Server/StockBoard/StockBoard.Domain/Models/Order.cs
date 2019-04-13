using System;
using StockBoard.Domain.Core.Models;

namespace StockBoard.Domain.Models
{
    public class Order : Entity
    {
        public Order(Guid id, double price, Guid stockId, int quantity, double commission)
        {
            Id = id;
            Price = price;
            StockId = stockId;
            Quantity = quantity;
            Commission = commission;

        }
        // Empty constructor for EF
        public Order() { }
        public Guid StockId { get; private set; }
        public double Price { get; private set; }
        public int Quantity { get; private set; }
        public double Commission { get; private set; }
    }
}