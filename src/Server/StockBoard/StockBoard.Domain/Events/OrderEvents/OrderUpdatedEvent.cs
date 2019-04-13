using System;
using StockBoard.Domain.Core.Events;

namespace StockBoard.Domain.Events.OrderEvents
{
    public class OrderUpdatedEvent : Event
    {
        public OrderUpdatedEvent(Guid id, Guid stockId, double price, int quantity, double commission)
        {
            Id = id;
            StockId = stockId;
            Price = price;
            Quantity = quantity;
            Commission = commission;
            AggregateId = id;
        }
        public Guid Id { get; private set; }
        public Guid StockId { get; private set; }
        public double Price { get; private set; }
        public int Quantity { get; private set; }
        public double Commission { get; private set; }

    }
}