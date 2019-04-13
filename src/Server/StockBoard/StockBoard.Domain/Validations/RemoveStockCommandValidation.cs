using StockBoard.Domain.Commands.StockCommands;

namespace StockBoard.Domain.Validations
{
    public class RemoveStockCommandValidation :StockValidation<RemoveStockCommand>
    {
        public RemoveStockCommandValidation()
        {
            ValidateId();
        }
    }
}