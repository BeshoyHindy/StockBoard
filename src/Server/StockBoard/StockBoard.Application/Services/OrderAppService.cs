using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using StockBoard.Application.Interfaces;
using StockBoard.Application.ViewModels;
using StockBoard.Domain.Commands.OrderCommands;
using StockBoard.Domain.Core.Bus;
using StockBoard.Domain.Interfaces;

namespace StockBoard.Application.Services
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IMediatorHandler _bus;

        public OrderAppService(IMapper mapper,
            IOrderRepository orderRepository,
            IMediatorHandler bus)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _bus = bus;
        }

        public IEnumerable<OrderViewModel> GetAll()
        {
            return _orderRepository.GetAll().ProjectTo<OrderViewModel>(_mapper.ConfigurationProvider);
        }

        public OrderViewModel GetById(Guid id)
        {
            return _mapper.Map<OrderViewModel>(_orderRepository.GetById(id));
        }

        public void AddNewOrder(OrderViewModel orderViewModel)
        {
            var addCommand = _mapper.Map<AddNewOrderCommand>(orderViewModel);
            _bus.SendCommand(addCommand);
        }

        public void Update(OrderViewModel orderViewModel)
        {
            var updateCommand = _mapper.Map<UpdateOrderCommand>(orderViewModel);
            _bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveOrderCommand(id);
            _bus.SendCommand(removeCommand);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}