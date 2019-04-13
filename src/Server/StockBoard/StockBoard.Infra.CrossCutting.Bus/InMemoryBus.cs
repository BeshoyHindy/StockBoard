using System.Threading.Tasks;
using MediatR;
using StockBoard.Domain.Core.Bus;
using StockBoard.Domain.Core.Commands;
using StockBoard.Domain.Core.Events;

namespace StockBoard.Infra.CrossCutting.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            //if we using event sourcing then we should save the event in eventStore here.
            return _mediator.Publish(@event);
        }
    }
}
