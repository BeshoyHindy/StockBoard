using System;
using System.Collections.Generic;
using StockBoard.Application.ViewModels;

namespace StockBoard.Application.Interfaces
{
    public interface IPersonAppService : IDisposable
    {
        void AddNewPerson(PersonViewModel personViewModel);
        IEnumerable<PersonViewModel> GetAll();
        PersonViewModel GetById(Guid id);
        void Update(PersonViewModel personViewModel);
        void Remove(Guid id);
    }
}
