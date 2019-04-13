using System;
using System.Collections.Generic;

namespace StockBoard.Application.ViewModels
{
    public class BrokerViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<PersonViewModel> Persons { get; set; }
        public ICollection<OrderViewModel> Orders { get; set; }
    }
}