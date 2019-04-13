using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StockBoard.Domain.Commands.BrokerCommands;
using StockBoard.Domain.Commands.StockCommands;
using StockBoard.Domain.Core.Bus;
using StockBoard.Domain.Core.Notifications;
using StockBoard.Domain.Events.BrokerEvents;
using StockBoard.Domain.Events.StockEvents;
using StockBoard.Domain.Interfaces;
using StockBoard.Domain.Models;

namespace StockBoard.Domain.CommandHandlers
{
    public class StockCommandHandler : CommandHandler,
        IRequestHandler<AddNewStockCommand, bool>,
        IRequestHandler<UpdateStockCommand, bool>,
        IRequestHandler<RemoveStockCommand, bool>
    {

        private readonly IStockRepository _stockRepository;
        private readonly IMediatorHandler _bus;

        public StockCommandHandler(IStockRepository stockRepository,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _stockRepository = stockRepository;
            _bus = bus;
        }

        public Task<bool> Handle(AddNewStockCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var stock = new Stock(Guid.NewGuid(), message.Name, message.Price);

            _stockRepository.Add(stock);

            if (Commit())
            {
                _bus.RaiseEvent(new StockAddedEvent(stock.Id, stock.Name, stock.Price));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateStockCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var stock = new Stock(message.Id, message.Name, message.Price);


            _stockRepository.Update(stock);

            if (Commit())
            {
                _bus.RaiseEvent(new StockUpdatedEvent(stock.Id, stock.Name, stock.Price));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveStockCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _stockRepository.Remove(message.Id);

            if (Commit())
            {
                _bus.RaiseEvent(new StockRemovedEvent(message.Id));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _stockRepository.Dispose();
        }
    }
}