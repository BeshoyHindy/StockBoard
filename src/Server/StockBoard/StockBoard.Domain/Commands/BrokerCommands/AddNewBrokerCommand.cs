using StockBoard.Domain.Commands.PersonCommands;
using StockBoard.Domain.Validations;

namespace StockBoard.Domain.Commands.BrokerCommands
{
    public class AddNewBrokerCommand : BrokerCommand
    {

        public AddNewBrokerCommand(string name)
        {
            Name = name;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddNewBrokerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}