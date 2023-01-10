using CustomStore.Core.Messages;
using FluentValidation;
using System;

namespace CustomStore.Sales.Application.Commands
{
    public class AddOrderItemCommand : Command
    {
        public Guid ClientId { get; private set; }
        public Guid ProductId { get; private set; }
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        public AddOrderItemCommand(Guid clientId, Guid productId, string name, int quantity, decimal price)
        {
            ClientId = clientId;
            ProductId = productId;
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddOrderItemCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AddOrderItemCommandValidation : AbstractValidator<AddOrderItemCommand>
    {
        public AddOrderItemCommandValidation()
        {
            RuleFor(c => c.ClientId)
                .NotEqual(Guid.Empty)
                .WithMessage("Invalid ClientId");

            RuleFor(c => c.ProductId)
                .NotEqual(Guid.Empty)
                .WithMessage("Invalid ProductId");

            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Product name cannot be empty");

            RuleFor(c => c.Quantity)
                .GreaterThan(0)
                .WithMessage("Min quantity is 1");

            RuleFor(c => c.Quantity)
                .LessThanOrEqualTo(50)
                .WithMessage("Max quantity is 50");

            RuleFor(c => c.Price)
                .GreaterThan(0)
                .WithMessage("Price should be greater than 0");
        }
    }
}
