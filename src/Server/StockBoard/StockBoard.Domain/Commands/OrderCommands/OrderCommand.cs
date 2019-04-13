using System;
using System.Collections.Generic;
using StockBoard.Domain.Core.Commands;
using StockBoard.Domain.Models;

namespace StockBoard.Domain.Commands.OrderCommands
{
    public abstract class OrderCommand : Command
    {
        public Guid Id { get; protected set; }
        public Guid StockId { get; protected set; }
        public double Price { get; protected set; }
        public int Quantity { get; protected set; }
        public double Commission { get; protected set; }
    }
}