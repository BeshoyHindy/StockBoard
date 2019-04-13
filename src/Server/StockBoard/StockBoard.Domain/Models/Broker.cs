using System;
using System.Collections.Generic;
using StockBoard.Domain.Core.Models;

namespace StockBoard.Domain.Models
{
    public class Broker : Entity
    {
        public Broker(Guid id, string name)
        {
            Id = id;
            Name = name;
            //Persons = persons;
            //Orders = orders;
        }
        // Empty constructor for EF
        protected Broker() { }

        public string Name { get; private set; }

        public virtual ICollection<Person> Persons { get;  set; }
        public virtual ICollection<Order> Orders { get;  set; }
    }
}