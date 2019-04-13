using StockBoard.Domain.Validations;

namespace StockBoard.Domain.Commands.StockCommands
{
    public class AddNewStockCommand : StockCommand
    {

        public AddNewStockCommand(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddNewStockCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}