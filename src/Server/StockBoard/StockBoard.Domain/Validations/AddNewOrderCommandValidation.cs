using StockBoard.Domain.Commands.OrderCommands;
using StockBoard.Domain.Commands.PersonCommands;

namespace StockBoard.Domain.Validations
{
    public class AddNewOrderCommandValidation : OrderValidation<AddNewOrderCommand>
    {
        public AddNewOrderCommandValidation()
        {
            ValidateStockId();

        }
    }
}