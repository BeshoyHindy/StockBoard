using StockBoard.Domain.Commands.BrokerCommands;

namespace StockBoard.Domain.Validations
{
    public class AddNewBrokerCommandValidation : BrokerValidation<AddNewBrokerCommand>
    {
        public AddNewBrokerCommandValidation()
        {
            ValidateName();

        }
    }
}