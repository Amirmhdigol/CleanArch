
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Shared
{
    public class CommandValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validator;

        public CommandValidationBehavior(IEnumerable<IValidator<TRequest>> validator)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var errors = _validator.Select(v => v.Validate(request))
                .SelectMany(res => res.Errors).Where(r => r != null);

            if(errors.Any())
            {
                var stringBuilder = new StringBuilder();
                foreach(var error in errors)
                    stringBuilder.AppendLine(error.ErrorMessage);

                throw new InvalidCommandException(stringBuilder.ToString());
            }
            var response = await next();
            return response;
        }
    }
}
