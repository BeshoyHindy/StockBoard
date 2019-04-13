using StockBoard.Domain.Commands.StockCommands;

namespace StockBoard.Domain.Validations
{
    public class UpdateStockCommandValidation : StockValidation<UpdateStockCommand>
    {
        public UpdateStockCommandValidation()
        {
            ValidateId();
            ValidateName();
        }
    }
}