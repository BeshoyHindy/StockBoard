using System;
using StockBoard.Domain.Core.Events;

namespace StockBoard.Domain.Events.StockEvents
{
    public class StockAddedEvent : Event
    {
        public StockAddedEvent(Guid id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;

            AggregateId = id;
        }
        public Guid Id { get; private set; }

        public string Name { get; private set; }
        public double Price { get; private set; }



    }
}