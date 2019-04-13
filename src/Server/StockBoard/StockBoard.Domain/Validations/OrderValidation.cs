using System;
using FluentValidation;
using StockBoard.Domain.Commands.OrderCommands;

namespace StockBoard.Domain.Validations
{
    public abstract class OrderValidation<T> : AbstractValidator<T> where T : OrderCommand
    {

        protected void ValidateId()
        {
            RuleFor(p => p.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateStockId()
        {
            RuleFor(p => p.StockId)
                .NotEqual(Guid.Empty);
        }

    }
}