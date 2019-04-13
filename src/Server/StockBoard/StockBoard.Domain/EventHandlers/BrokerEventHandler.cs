using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using StockBoard.Domain.Events.BrokerEvents;
using StockBoard.Domain.Events.PersonEvents;
using StockBoard.Domain.RealTime;

namespace StockBoard.Domain.EventHandlers
{
    public class BrokerEventHandler :
        INotificationHandler<BrokerAddedEvent>,
        INotificationHandler<BrokerUpdatedEvent>,
        INotificationHandler<BrokerRemovedEvent>
    {
        private readonly IHubContext<StockEventsClientHub> _hubContext;

        public BrokerEventHandler(IHubContext<StockEventsClientHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public Task Handle(BrokerAddedEvent @event, CancellationToken cancellationToken)
        {
            return _hubContext.Clients.All.SendAsync("brokerAdded", @event, cancellationToken);
        }
        public Task Handle(BrokerUpdatedEvent @event, CancellationToken cancellationToken)
        {
            return _hubContext.Clients.All.SendAsync("brokerUpdated", @event, cancellationToken);
        }

        public Task Handle(BrokerRemovedEvent @event, CancellationToken cancellationToken)
        {
            return _hubContext.Clients.All.SendAsync("brokerRemoved", @event, cancellationToken);

        }
    }
}