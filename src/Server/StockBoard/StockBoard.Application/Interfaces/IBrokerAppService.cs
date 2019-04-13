using System;
using System.Collections.Generic;
using StockBoard.Application.ViewModels;

namespace StockBoard.Application.Interfaces
{
    public interface IBrokerAppService : IDisposable
    {
        void AddNewBroker(BrokerViewModel brokerViewModel);
        IEnumerable<BrokerViewModel> GetAll();
        BrokerViewModel GetById(Guid id);
        void Update(BrokerViewModel brokerViewModel);
        void Remove(Guid id);
    }
}