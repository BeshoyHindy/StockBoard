using System;
using StockBoard.Domain.Commands.PersonCommands;
using StockBoard.Domain.Validations;

namespace StockBoard.Domain.Commands.StockCommands
{
    public class RemoveStockCommand : StockCommand
    {
        public RemoveStockCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveStockCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}