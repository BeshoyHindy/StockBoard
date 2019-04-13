using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StockBoard.Domain.Commands.BrokerCommands;
using StockBoard.Domain.Commands.PersonCommands;
using StockBoard.Domain.Core.Bus;
using StockBoard.Domain.Core.Notifications;
using StockBoard.Domain.Events.BrokerEvents;
using StockBoard.Domain.Events.PersonEvents;
using StockBoard.Domain.Interfaces;
using StockBoard.Domain.Models;

namespace StockBoard.Domain.CommandHandlers
{
    public class BrokerCommandHandler : CommandHandler,
        IRequestHandler<AddNewBrokerCommand, bool>,
        IRequestHandler<UpdateBrokerCommand, bool>,
        IRequestHandler<RemoveBrokerCommand, bool>
    {
        private readonly IBrokerRepository _brokerRepository;
        private readonly IMediatorHandler _bus;

        public BrokerCommandHandler(IBrokerRepository brokerRepository,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _brokerRepository = brokerRepository;
            _bus = bus;
        }

        public Task<bool> Handle(AddNewBrokerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var broker = new Broker(Guid.NewGuid(), message.Name);

            _brokerRepository.Add(broker);

            if (Commit())
            {
                _bus.RaiseEvent(new BrokerAddedEvent(broker.Id, broker.Name));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateBrokerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var broker = new Broker(message.Id, message.Name);


            _brokerRepository.Update(broker);

            if (Commit())
            {
                _bus.RaiseEvent(new BrokerUpdatedEvent(broker.Id, broker.Name));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveBrokerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _brokerRepository.Remove(message.Id);

            if (Commit())
            {
                _bus.RaiseEvent(new BrokerRemovedEvent(message.Id));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _brokerRepository.Dispose();
        }
    }
}