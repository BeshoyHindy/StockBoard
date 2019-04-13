using AutoMapper;
using StockBoard.Application.ViewModels;
using StockBoard.Domain.Commands.BrokerCommands;
using StockBoard.Domain.Commands.OrderCommands;
using StockBoard.Domain.Commands.PersonCommands;
using StockBoard.Domain.Commands.StockCommands;

namespace StockBoard.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PersonViewModel, AddNewPersonCommand>()
                .ConstructUsing(p => new AddNewPersonCommand(p.Name));

            //CreateMap<PersonViewModel, UpdatePersonCommand>()
            //    .ConstructUsing(p => new UpdatePersonCommand(p.Id, p.Name, p.Orders));



            CreateMap<BrokerViewModel, AddNewBrokerCommand>()
                .ConstructUsing(b => new AddNewBrokerCommand(b.Name));

            CreateMap<StockViewModel, AddNewStockCommand>()
                .ConstructUsing(s => new AddNewStockCommand(s.Name, s.Price));

            CreateMap<StockViewModel, UpdateStockCommand>()
                .ConstructUsing(s => new UpdateStockCommand(s.Id, s.Name, s.Price));


            CreateMap<OrderViewModel, AddNewOrderCommand>()
                .ConstructUsing(o => new AddNewOrderCommand(o.StockId, o.Price, o.Quantity, o.Commission));

        }
    }
}
