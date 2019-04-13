using System;
using StockBoard.Domain.Core.Events;

namespace StockBoard.Domain.Events.BrokerEvents
{
    public class BrokerUpdatedEvent : Event
    {
        public BrokerUpdatedEvent(Guid id, string name)
        {
            Id = id;
            Name = name;

            AggregateId = id;
        }
        public Guid Id { get; private set; }

        public string Name { get; private set; }

    }
}