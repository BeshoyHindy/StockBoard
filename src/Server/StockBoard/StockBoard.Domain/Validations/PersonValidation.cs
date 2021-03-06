﻿using System;
using FluentValidation;
using StockBoard.Domain.Commands;
using StockBoard.Domain.Commands.PersonCommands;

namespace StockBoard.Domain.Validations
{
    public abstract class PersonValidation<T> : AbstractValidator<T> where T : PersonCommand
    {

        protected void ValidateId()
        {
            RuleFor(p => p.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateName()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 100).WithMessage("The Author Name must have between 2 and 100 characters");
        }
    }
}