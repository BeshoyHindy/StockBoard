using System;
using System.Collections.Generic;
using StockBoard.Domain.Core.Commands;
using StockBoard.Domain.Models;

namespace StockBoard.Domain.Commands.BrokerCommands
{
    public abstract class BrokerCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
    }
}