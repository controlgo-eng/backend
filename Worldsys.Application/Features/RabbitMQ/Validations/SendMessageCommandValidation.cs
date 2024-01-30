using FluentValidation;
using Worldsys.Application.Features.RabbitMQ.Command;

namespace Worldsys.Application.Features.RabbitMQ.Validations
{
    public class SendMessageCommandValidation : AbstractValidator<SendMessageCommand>
    {
        public SendMessageCommandValidation()
        {            
            this.RuleFor(command => command.Title)
                .NotEmpty()
                    .WithMessage("El titulo no puede ser vacio.");

            this.RuleFor(command => command.Body)
                .NotEmpty()
                    .WithMessage("El body no puede ser vacio.");

        }
    }
}
