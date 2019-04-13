using System;
using StockBoard.Domain.Validations;

namespace StockBoard.Domain.Commands.OrderCommands
{
    public class RemoveOrderCommand : OrderCommand
    {
        public RemoveOrderCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveOrderCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}