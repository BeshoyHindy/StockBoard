using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using StockBoard.Application.Interfaces;
using StockBoard.Application.ViewModels;
using StockBoard.Domain.Commands.PersonCommands;
using StockBoard.Domain.Core.Bus;
using StockBoard.Domain.Interfaces;

namespace StockBoard.Application.Services
{
    public class PersonAppService : IPersonAppService
    {
        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;
        private readonly IMediatorHandler _bus;

        public PersonAppService(IMapper mapper,
            IPersonRepository personRepository,
                                  IMediatorHandler bus)
        {
            _mapper = mapper;
            _personRepository = personRepository;
            _bus = bus;
        }

        public IEnumerable<PersonViewModel> GetAll()
        {
            return _personRepository.GetAll().ProjectTo<PersonViewModel>(_mapper.ConfigurationProvider);
        }

        public PersonViewModel GetById(Guid id)
        {
            return _mapper.Map<PersonViewModel>(_personRepository.GetById(id));
        }

        public void AddNewPerson(PersonViewModel personViewModel)
        {
            var addCommand = _mapper.Map<AddNewPersonCommand>(personViewModel);
            _bus.SendCommand(addCommand);
        }

        public void Update(PersonViewModel personViewModel)
        {
            var updateCommand = _mapper.Map<UpdatePersonCommand>(personViewModel);
            _bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemovePersonCommand(id);
            _bus.SendCommand(removeCommand);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
