using System;
using System.Collections.Generic;
using StockBoard.Domain.Models;
using StockBoard.Domain.Validations;

namespace StockBoard.Domain.Commands.OrderCommands
{
    public class UpdateOrderCommand : OrderCommand
    {


        public UpdateOrderCommand(Guid id, Guid stockId, double price, int quantity, double commission)
        {
            Id = id;
            StockId = stockId;
            Price = price;
            Quantity = quantity;
            Commission = commission;
        }


        public override bool IsValid()
        {
            ValidationResult = new UpdateOrderCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}