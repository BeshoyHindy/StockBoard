using StockBoard.Domain.Commands;
using StockBoard.Domain.Commands.PersonCommands;

namespace StockBoard.Domain.Validations
{
    public class AddNewPersonCommandValidation : PersonValidation<AddNewPersonCommand>
    {
        public AddNewPersonCommandValidation()
        {
            ValidateName();

        }
    }
}