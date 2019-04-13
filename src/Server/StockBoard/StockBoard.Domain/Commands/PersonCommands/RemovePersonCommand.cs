using System;
using StockBoard.Domain.Validations;

namespace StockBoard.Domain.Commands.PersonCommands
{
    public class RemovePersonCommand : PersonCommand
    {
        public RemovePersonCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemovePersonCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}