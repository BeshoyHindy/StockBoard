using System.Threading.Tasks;
using StockBoard.Domain.Core.Commands;
using StockBoard.Domain.Core.Events;

namespace StockBoard.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
