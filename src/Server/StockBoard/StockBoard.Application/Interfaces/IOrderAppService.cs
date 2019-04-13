using System;
using System.Collections.Generic;
using StockBoard.Application.ViewModels;

namespace StockBoard.Application.Interfaces
{
    public interface IOrderAppService : IDisposable
    {
        void AddNewOrder(OrderViewModel orderViewModel);
        IEnumerable<OrderViewModel> GetAll();
        OrderViewModel GetById(Guid id);
        void Update(OrderViewModel orderViewModel);
        void Remove(Guid id);
    }
}