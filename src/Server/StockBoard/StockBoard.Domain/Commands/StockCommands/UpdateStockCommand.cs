using System;
using System.Collections.Generic;
using StockBoard.Domain.Commands.PersonCommands;
using StockBoard.Domain.Models;
using StockBoard.Domain.Validations;

namespace StockBoard.Domain.Commands.StockCommands
{
    public class UpdateStockCommand : StockCommand
    {


        public UpdateStockCommand(Guid id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;

        }


        public override bool IsValid()
        {
            ValidationResult = new UpdateStockCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}