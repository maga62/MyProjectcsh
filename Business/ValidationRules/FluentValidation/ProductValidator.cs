﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.Unitprice).NotEmpty();
            RuleFor(p => p.Unitprice).GreaterThan(0);
            RuleFor(p => p.Unitprice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
            RuleFor(p => p.ProductName).Must(StratWithA).WithMessage("ürünler A harfi ile başlamalı");
        }

        private bool StratWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
