using StockBoard.Domain.Interfaces;
using StockBoard.Domain.Models;
using StockBoard.Infra.Data.Context;

namespace StockBoard.Infra.Data.Repository
{
    public class StockRepository : Repository<Stock>, IStockRepository
    {
        public StockRepository(StockBoardContext context)
            : base(context)
        {

        }

    }
}