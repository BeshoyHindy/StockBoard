using System;
using System.Collections.Generic;

namespace StockBoard.Application.ViewModels
{
    public class PersonViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<OrderViewModel> Orders { get; set; }

    }
}