using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using StockBoard.Domain.Events;
using StockBoard.Domain.Events.OrderEvents;
using StockBoard.Domain.Events.PersonEvents;
using StockBoard.Domain.RealTime;

namespace StockBoard.Domain.EventHandlers
{
    public class PersonEventHandler :
        INotificationHandler<PersonAddedEvent>,
        INotificationHandler<PersonUpdatedEvent>,
        INotificationHandler<PersonRemovedEvent>
    {
        private readonly IHubContext<StockEventsClientHub> _hubContext;

        public PersonEventHandler(IHubContext<StockEventsClientHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public Task Handle(PersonAddedEvent @event, CancellationToken cancellationToken)
        {
            // Send notification by author name and post title 

            return _hubContext.Clients.All.SendAsync("personAdded", @event, cancellationToken);
        }
        public Task Handle(PersonUpdatedEvent @event, CancellationToken cancellationToken)
        {
            // Send some notification by updated post
            return _hubContext.Clients.All.SendAsync("personUpdated", @event, cancellationToken);
        }

        public Task Handle(PersonRemovedEvent @event, CancellationToken cancellationToken)
        {
            // Send some notification by deleted post
            return _hubContext.Clients.All.SendAsync("personRemoved", @event, cancellationToken);

        }
    }
}