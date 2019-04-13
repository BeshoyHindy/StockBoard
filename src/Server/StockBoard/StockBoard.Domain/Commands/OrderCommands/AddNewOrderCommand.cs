using System;
using StockBoard.Domain.Validations;

namespace StockBoard.Domain.Commands.OrderCommands
{
    public class AddNewOrderCommand : OrderCommand
    {

        public AddNewOrderCommand(Guid stockId, double price, int quantity, double commission)
        {
            StockId = stockId;
            Price = price;
            Quantity = quantity;
            Commission = commission;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddNewOrderCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}