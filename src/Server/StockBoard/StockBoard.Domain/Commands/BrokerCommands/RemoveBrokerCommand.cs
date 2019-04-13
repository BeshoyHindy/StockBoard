using System;
using StockBoard.Domain.Commands.PersonCommands;
using StockBoard.Domain.Validations;

namespace StockBoard.Domain.Commands.BrokerCommands
{
    public class RemoveBrokerCommand : BrokerCommand
    {
        public RemoveBrokerCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveBrokerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}