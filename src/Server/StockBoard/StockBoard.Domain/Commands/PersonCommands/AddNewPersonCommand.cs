using System;
using StockBoard.Domain.Validations;

namespace StockBoard.Domain.Commands.PersonCommands
{
    public class AddNewPersonCommand : PersonCommand
    {

        public AddNewPersonCommand(string name)
        {
            Name = name;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddNewPersonCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}