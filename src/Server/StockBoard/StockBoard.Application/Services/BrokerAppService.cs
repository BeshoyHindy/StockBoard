using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using StockBoard.Application.Interfaces;
using StockBoard.Application.ViewModels;
using StockBoard.Domain.Commands.BrokerCommands;
using StockBoard.Domain.Core.Bus;
using StockBoard.Domain.Interfaces;

namespace StockBoard.Application.Services
{
    public class BrokerAppService : IBrokerAppService
    {
        private readonly IMapper _mapper;
        private readonly IBrokerRepository _brokerRepository;
        private readonly IMediatorHandler _bus;

        public BrokerAppService(IMapper mapper,
            IBrokerRepository brokerRepository,
            IMediatorHandler bus)
        {
            _mapper = mapper;
            _brokerRepository = brokerRepository;
            _bus = bus;
        }

        public IEnumerable<BrokerViewModel> GetAll()
        {
            return _brokerRepository.GetAll().ProjectTo<BrokerViewModel>(_mapper.ConfigurationProvider);
        }

        public BrokerViewModel GetById(Guid id)
        {
            return _mapper.Map<BrokerViewModel>(_brokerRepository.GetById(id));
        }

        public void AddNewBroker(BrokerViewModel brokerViewModel)
        {
            var addCommand = _mapper.Map<AddNewBrokerCommand>(brokerViewModel);
            _bus.SendCommand(addCommand);
        }

        public void Update(BrokerViewModel brokerViewModel)
        {
            var updateCommand = _mapper.Map<UpdateBrokerCommand>(brokerViewModel);
            _bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveBrokerCommand(id);
            _bus.SendCommand(removeCommand);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}