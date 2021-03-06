﻿using System;
using StockBoard.Domain.Core.Events;

namespace StockBoard.Domain.Events.StockEvents
{
    public class StockRemovedEvent : Event
    {
        public StockRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}