using StockBoard.Domain.Commands.OrderCommands;

namespace StockBoard.Domain.Validations
{
    public class UpdateOrderCommandValidation : OrderValidation<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidation()
        {
            ValidateId();
            ValidateStockId();
        }
    }
}