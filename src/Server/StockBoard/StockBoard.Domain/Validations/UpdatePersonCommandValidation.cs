using StockBoard.Domain.Commands;
using StockBoard.Domain.Commands.PersonCommands;

namespace StockBoard.Domain.Validations
{
    public class UpdatePersonCommandValidation : PersonValidation<UpdatePersonCommand>
    {
        public UpdatePersonCommandValidation()
        {
            ValidateId();
            ValidateName();
        }
    }
}