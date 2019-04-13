using StockBoard.Domain.Commands.BrokerCommands;
using StockBoard.Domain.Commands.PersonCommands;

namespace StockBoard.Domain.Validations
{
    public class RemoveBrokerCommandValidation : BrokerValidation<RemoveBrokerCommand>
    {
        public RemoveBrokerCommandValidation()
        {
            ValidateId();
        }
    }
}