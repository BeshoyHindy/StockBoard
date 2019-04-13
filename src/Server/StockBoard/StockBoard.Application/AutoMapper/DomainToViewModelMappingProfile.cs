using AutoMapper;
using StockBoard.Application.ViewModels;
using StockBoard.Domain.Models;

namespace StockBoard.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Person, PersonViewModel>();
            CreateMap<Stock, StockViewModel>();
            CreateMap<Broker, BrokerViewModel>();
            CreateMap<Order, OrderViewModel>();
        }
    }
}
