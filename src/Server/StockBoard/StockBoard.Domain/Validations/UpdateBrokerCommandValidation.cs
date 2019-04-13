using StockBoard.Domain.Commands.BrokerCommands;
using StockBoard.Domain.Commands.PersonCommands;

namespace StockBoard.Domain.Validations
{
    public class UpdateBrokerCommandValidation : BrokerValidation<UpdateBrokerCommand>
    {
        public UpdateBrokerCommandValidation()
        {
            ValidateId();
            ValidateName();
        }
    }
}