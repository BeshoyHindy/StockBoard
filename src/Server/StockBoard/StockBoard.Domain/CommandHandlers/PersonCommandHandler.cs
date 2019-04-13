using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StockBoard.Domain.Commands;
using StockBoard.Domain.Commands.OrderCommands;
using StockBoard.Domain.Commands.PersonCommands;
using StockBoard.Domain.Commands.StockCommands;
using StockBoard.Domain.Core.Bus;
using StockBoard.Domain.Core.Notifications;
using StockBoard.Domain.Events;
using StockBoard.Domain.Events.PersonEvents;
using StockBoard.Domain.Interfaces;
using StockBoard.Domain.Models;

namespace StockBoard.Domain.CommandHandlers
{
    public class PersonCommandHandler : CommandHandler,
        IRequestHandler<AddNewPersonCommand, bool>,
        IRequestHandler<UpdatePersonCommand, bool>,
        IRequestHandler<RemovePersonCommand, bool>
    {
        private readonly IPersonRepository _postRepository;
        private readonly IMediatorHandler _bus;

        public PersonCommandHandler(IPersonRepository postRepository,
                                  IUnitOfWork uow,
                                  IMediatorHandler bus,
                                  INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _postRepository = postRepository;
            _bus = bus;
        }

        public Task<bool> Handle(AddNewPersonCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var person = new Person(Guid.NewGuid(), message.Name);

            _postRepository.Add(person);

            if (Commit())
            {
                _bus.RaiseEvent(new PersonAddedEvent(person.Id, person.Name));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdatePersonCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var person = new Person(message.Id, message.Name);


            _postRepository.Update(person);

            if (Commit())
            {
                _bus.RaiseEvent(new PersonUpdatedEvent(person.Id, person.Name));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemovePersonCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            _postRepository.Remove(message.Id);

            if (Commit())
            {
                _bus.RaiseEvent(new PersonRemovedEvent(message.Id));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _postRepository.Dispose();
        }
    }
}