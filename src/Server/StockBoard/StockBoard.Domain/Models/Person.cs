using System;
using System.Collections.Generic;
using StockBoard.Domain.Core.Models;

namespace StockBoard.Domain.Models
{
    public class Person : Entity
    {
        public Person(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        // Empty constructor for EF
        protected Person() { }
        public string Name { get; private set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}