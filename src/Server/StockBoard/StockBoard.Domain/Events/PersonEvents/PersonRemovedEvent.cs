using System;
using StockBoard.Domain.Core.Events;

namespace StockBoard.Domain.Events.PersonEvents
{
    public class PersonRemovedEvent : Event
    {
        public PersonRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}