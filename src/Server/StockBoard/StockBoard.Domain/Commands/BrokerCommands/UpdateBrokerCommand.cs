using System;
using System.Collections.Generic;
using StockBoard.Domain.Commands.PersonCommands;
using StockBoard.Domain.Models;
using StockBoard.Domain.Validations;

namespace StockBoard.Domain.Commands.BrokerCommands
{
    public class UpdateBrokerCommand : BrokerCommand
    {


        public UpdateBrokerCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        
        }


        public override bool IsValid()
        {
            ValidationResult = new UpdateBrokerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}