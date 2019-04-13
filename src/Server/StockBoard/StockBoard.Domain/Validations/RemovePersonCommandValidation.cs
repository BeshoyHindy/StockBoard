using StockBoard.Domain.Commands;
using StockBoard.Domain.Commands.PersonCommands;

namespace StockBoard.Domain.Validations
{
    public class RemovePersonCommandValidation : PersonValidation<RemovePersonCommand>
    {
        public RemovePersonCommandValidation()
        {
            ValidateId();
        }
    }
}