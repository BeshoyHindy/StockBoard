using System;
using StockBoard.Domain.Core.Events;

namespace StockBoard.Domain.Events.OrderEvents
{
    public class OrderRemovedEvent : Event
    {
        public OrderRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}