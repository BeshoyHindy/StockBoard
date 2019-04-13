using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using StockBoard.Domain.Events.OrderEvents;
using StockBoard.Domain.Events.PersonEvents;
using StockBoard.Domain.RealTime;

namespace StockBoard.Domain.EventHandlers
{
    public class OrderEventHandler :
        INotificationHandler<OrderAddedEvent>,
        INotificationHandler<OrderUpdatedEvent>,
        INotificationHandler<OrderRemovedEvent>
    {
        private readonly IHubContext<StockEventsClientHub> _hubContext;

        public OrderEventHandler(IHubContext<StockEventsClientHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public Task Handle(OrderAddedEvent @event, CancellationToken cancellationToken)
        {
            return _hubContext.Clients.All.SendAsync("orderAdded", @event, cancellationToken);
        }
        public Task Handle(OrderUpdatedEvent @event, CancellationToken cancellationToken)
        {
            return _hubContext.Clients.All.SendAsync("orderUpdated", @event, cancellationToken);
        }

        public Task Handle(OrderRemovedEvent @event, CancellationToken cancellationToken)
        {
            return _hubContext.Clients.All.SendAsync("orderRemoved", @event, cancellationToken);

        }
    }
}