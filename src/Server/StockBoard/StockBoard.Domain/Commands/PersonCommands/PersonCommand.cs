using System;
using System.Collections.Generic;
using StockBoard.Domain.Core.Commands;
using StockBoard.Domain.Models;

namespace StockBoard.Domain.Commands.PersonCommands
{
    public abstract class PersonCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public virtual ICollection<Order> Orders { get; protected set; }
    }
}