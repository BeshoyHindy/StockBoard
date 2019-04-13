﻿using System.Linq;
using StockBoard.Domain.Interfaces;
using StockBoard.Domain.Models;
using StockBoard.Infra.Data.Context;

namespace StockBoard.Infra.Data.Repository
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(StockBoardContext context)
            : base(context)
        {

        }

    }
}
