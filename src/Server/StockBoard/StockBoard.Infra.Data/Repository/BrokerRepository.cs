using StockBoard.Domain.Interfaces;
using StockBoard.Domain.Models;
using StockBoard.Infra.Data.Context;

namespace StockBoard.Infra.Data.Repository
{
    public class BrokerRepository : Repository<Broker>, IBrokerRepository
    {
        public BrokerRepository(StockBoardContext context)
            : base(context)
        {

        }

    }
}