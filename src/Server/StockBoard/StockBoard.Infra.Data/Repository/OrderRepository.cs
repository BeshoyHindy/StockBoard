using StockBoard.Domain.Interfaces;
using StockBoard.Domain.Models;
using StockBoard.Infra.Data.Context;

namespace StockBoard.Infra.Data.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(StockBoardContext context)
            : base(context)
        {

        }

    }
}