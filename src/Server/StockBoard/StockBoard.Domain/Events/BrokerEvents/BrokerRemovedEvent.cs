using System;
using StockBoard.Domain.Core.Events;

namespace StockBoard.Domain.Events.BrokerEvents
{
    public class BrokerRemovedEvent : Event
    {
        public BrokerRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}