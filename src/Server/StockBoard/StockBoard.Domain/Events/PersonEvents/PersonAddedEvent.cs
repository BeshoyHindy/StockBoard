using System;
using StockBoard.Domain.Core.Events;

namespace StockBoard.Domain.Events.PersonEvents
{
    public class PersonAddedEvent : Event
    {
        public PersonAddedEvent(Guid id, string name)
        {
            Id = id;
            Name = name;


            AggregateId = id;
        }
        public Guid Id { get; private set; }

        public string Name { get; private set; }



    }
}