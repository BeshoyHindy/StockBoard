using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using StockBoard.Application.Interfaces;
using StockBoard.Application.ViewModels;
using StockBoard.Domain.Commands.StockCommands;
using StockBoard.Domain.Core.Bus;
using StockBoard.Domain.Interfaces;

namespace StockBoard.Application.Services
{
    public class StockAppService : IStockAppService
    {
        private readonly IMapper _mapper;
        private readonly IStockRepository _stockRepository;
        private readonly IMediatorHandler _bus;

        public StockAppService(IMapper mapper,
            IStockRepository stockRepository,
            IMediatorHandler bus)
        {
            _mapper = mapper;
            _stockRepository = stockRepository;
            _bus = bus;
        }

        public IEnumerable<StockViewModel> GetAll()
        {
            return _stockRepository.GetAll().ProjectTo<StockViewModel>(_mapper.ConfigurationProvider);
        }

        public StockViewModel GetById(Guid id)
        {
            return _mapper.Map<StockViewModel>(_stockRepository.GetById(id));
        }

        public void AddNewStock(StockViewModel stockViewModel)
        {
            var addCommand = _mapper.Map<AddNewStockCommand>(stockViewModel);
            _bus.SendCommand(addCommand);
        }

        public void Update(StockViewModel stockViewModel)
        {
            var updateCommand = _mapper.Map<UpdateStockCommand>(stockViewModel);
            _bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveStockCommand(id);
            _bus.SendCommand(removeCommand);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}