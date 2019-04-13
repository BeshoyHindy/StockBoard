using StockBoard.Domain.Interfaces;
using StockBoard.Infra.Data.Context;

namespace StockBoard.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StockBoardContext _context;

        public UnitOfWork(StockBoardContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
