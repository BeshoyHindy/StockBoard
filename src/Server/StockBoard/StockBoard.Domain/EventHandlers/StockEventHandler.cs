using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using StockBoard.Domain.Events.StockEvents;
using StockBoard.Domain.RealTime;

namespace StockBoard.Domain.EventHandlers
{
    public class StockEventHandler :
        INotificationHandler<StockAddedEvent>,
        INotificationHandler<StockUpdatedEvent>,
        INotificationHandler<StockRemovedEvent>
    {
        private readonly IHubContext<StockEventsClientHub> _hubContext;

        public StockEventHandler(IHubContext<StockEventsClientHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public Task Handle(StockAddedEvent @event, CancellationToken cancellationToken)
        {
            return _hubContext.Clients.All.SendAsync("stockAdded", @event, cancellationToken);
        }
        public Task Handle(StockUpdatedEvent @event, CancellationToken cancellationToken)
        {
            return _hubContext.Clients.All.SendAsync("stockUpdated", @event, cancellationToken);
        }

        public Task Handle(StockRemovedEvent @event, CancellationToken cancellationToken)
        {
            return _hubContext.Clients.All.SendAsync("stockRemoved", @event, cancellationToken);
        }
    }
}