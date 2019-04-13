using System;
using System.Collections.Generic;
using StockBoard.Application.ViewModels;

namespace StockBoard.Application.Interfaces
{
    public interface IStockAppService : IDisposable
    {
        void AddNewStock(StockViewModel stockViewModel);
        IEnumerable<StockViewModel> GetAll();
        StockViewModel GetById(Guid id);
        void Update(StockViewModel stockViewModel);
        void Remove(Guid id);
    }
}