using System;

namespace StockBoard.Application.ViewModels
{
    public class StockViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}