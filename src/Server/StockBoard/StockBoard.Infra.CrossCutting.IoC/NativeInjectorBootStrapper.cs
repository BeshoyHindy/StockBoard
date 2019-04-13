

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using StockBoard.Application.Interfaces;
using StockBoard.Application.Services;
using StockBoard.Domain.CommandHandlers;
using StockBoard.Domain.Commands.BrokerCommands;
using StockBoard.Domain.Commands.OrderCommands;
using StockBoard.Domain.Commands.PersonCommands;
using StockBoard.Domain.Commands.StockCommands;
using StockBoard.Domain.Core.Bus;
using StockBoard.Domain.Core.Notifications;
using StockBoard.Domain.EventHandlers;
using StockBoard.Domain.Events.BrokerEvents;
using StockBoard.Domain.Events.OrderEvents;
using StockBoard.Domain.Events.PersonEvents;
using StockBoard.Domain.Events.StockEvents;
using StockBoard.Domain.Interfaces;
using StockBoard.Infra.CrossCutting.Bus;
using StockBoard.Infra.Data.Context;
using StockBoard.Infra.Data.Repository;
using StockBoard.Infra.Data.UoW;

namespace StockBoard.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();


            // Application
            services.AddScoped<IPersonAppService, PersonAppService>();
            services.AddScoped<IStockAppService, StockAppService>();
            services.AddScoped<IBrokerAppService, BrokerAppService>();
            services.AddScoped<IOrderAppService, OrderAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<PersonAddedEvent>,   PersonEventHandler>();
            services.AddScoped<INotificationHandler<PersonUpdatedEvent>, PersonEventHandler>();
            services.AddScoped<INotificationHandler<PersonRemovedEvent>, PersonEventHandler>();

            services.AddScoped<INotificationHandler<StockAddedEvent>,   StockEventHandler>();
            services.AddScoped<INotificationHandler<StockUpdatedEvent>, StockEventHandler>();
            services.AddScoped<INotificationHandler<StockRemovedEvent>, StockEventHandler>();

            services.AddScoped<INotificationHandler<BrokerAddedEvent>,   BrokerEventHandler>();
            services.AddScoped<INotificationHandler<BrokerUpdatedEvent>, BrokerEventHandler>();
            services.AddScoped<INotificationHandler<BrokerRemovedEvent>, BrokerEventHandler>();

            services.AddScoped<INotificationHandler<OrderAddedEvent>,   OrderEventHandler>();
            services.AddScoped<INotificationHandler<OrderUpdatedEvent>, OrderEventHandler>();
            services.AddScoped<INotificationHandler<OrderRemovedEvent>, OrderEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<AddNewPersonCommand, bool>, PersonCommandHandler>();
            services.AddScoped<IRequestHandler<UpdatePersonCommand, bool>, PersonCommandHandler>();
            services.AddScoped<IRequestHandler<RemovePersonCommand, bool>, PersonCommandHandler>();

            services.AddScoped<IRequestHandler<AddNewStockCommand, bool>, StockCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateStockCommand, bool>, StockCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveStockCommand, bool>, StockCommandHandler>();

            services.AddScoped<IRequestHandler<AddNewBrokerCommand, bool>, BrokerCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateBrokerCommand, bool>, BrokerCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveBrokerCommand, bool>, BrokerCommandHandler>();

            services.AddScoped<IRequestHandler<AddNewOrderCommand, bool>, OrderCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateOrderCommand, bool>, OrderCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveOrderCommand, bool>, OrderCommandHandler>();

            // Infra - Data
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IBrokerRepository, BrokerRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<StockBoardContext>();

            //IConfigurationRoot config = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")    
            //    .Build();

            //services.AddDbContext<SimpleBlogContext>(
            //        options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            ;
        }
    }
}