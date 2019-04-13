using System;
using StockBoard.Domain.Core.Commands;

namespace StockBoard.Domain.Commands.StockCommands
{
    public abstract class StockCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public double Price { get; protected set; }
    }
}