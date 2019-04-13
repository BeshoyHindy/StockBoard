using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StockBoard.Domain.Commands.OrderCommands;
using StockBoard.Domain.Commands.StockCommands;
using StockBoard.Domain.Core.Bus;
using StockBoard.Domain.Core.Notifications;
using StockBoard.Domain.Events.OrderEvents;
using StockBoard.Domain.Events.StockEvents;
using StockBoard.Domain.Interfaces;
using StockBoard.Domain.Models;

namespace StockBoard.Domain.CommandHandlers
{
    public class OrderCommandHandler : CommandHandler,
        IRequestHandler<AddNewOrderCommand, bool>,
        IRequestHandler<UpdateOrderCommand, bool>,
        IRequestHandler<RemoveOrderCommand, bool>
    {

        private readonly IOrderRepository _orderRepository;
        private readonly IMediatorHandler _bus;

        public OrderCommandHandler(IOrderRepository orderRepository,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _orderRepository = orderRepository;
            _bus = bus;
        }

        public Task<bool> Handle(AddNewOrderCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var order = new Order(Guid.NewGuid(), message.Price, message.StockId, message.Quantity, message.Commission);

            _orderRepository.Add(order);

            if (Commit())
            {
                _bus.RaiseEvent(new OrderAddedEvent(order.Id, order.StockId, order.Price, order.Quantity, order.Commission));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateOrderCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var order = new Order(message.Id, message.Price, message.StockId, message.Quantity, message.Commission);


            _orderRepository.Update(order);

            if (Commit())
            {
                _bus.RaiseEvent(new OrderUpdatedEvent(order.Id, order.StockId, order.Price, order.Quantity, order.Commission));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveOrderCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _orderRepository.Remove(message.Id);

            if (Commit())
            {
                _bus.RaiseEvent(new OrderRemovedEvent(message.Id));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _orderRepository.Dispose();
        }
    }
}