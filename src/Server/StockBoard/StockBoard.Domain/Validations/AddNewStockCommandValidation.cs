using StockBoard.Domain.Commands.StockCommands;

namespace StockBoard.Domain.Validations
{
    public class AddNewStockCommandValidation : StockValidation<AddNewStockCommand>
    {
        public AddNewStockCommandValidation()
        {
            ValidateName();

        }
    }
}