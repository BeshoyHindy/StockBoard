using System;
using System.Collections.Generic;
using StockBoard.Domain.Models;
using StockBoard.Domain.Validations;

namespace StockBoard.Domain.Commands.PersonCommands
{
    public class UpdatePersonCommand : PersonCommand
    {


        public UpdatePersonCommand(Guid id, string name, ICollection<Order> orders)
        {
            Id = id;
            Name = name;
            Orders = orders;

        }


        public override bool IsValid()
        {
            ValidationResult = new UpdatePersonCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}