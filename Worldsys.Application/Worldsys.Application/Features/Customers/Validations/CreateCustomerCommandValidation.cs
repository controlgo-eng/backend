using FluentValidation;
using Worldsys.Application.Features.Customers.Command;


namespace Worldsys.Application.Features.Customers.Validations
{
    public class CreateCustomerCommandValidation : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidation()
        {
            this.RuleFor(command => command.DocumentNumber)
                .GreaterThan(0)
                    .WithMessage("El numero de documento del cliente debe ser un número mayor a cero.");

            this.RuleFor(command => command.Name)                
                .NotEmpty()
                    .WithMessage("El nombre no puede ser vacio.");

            this.RuleFor(command => command.Surname)                
                .NotEmpty()
                    .WithMessage("El apellido no puede ser vacio.");

        }
    }
}
