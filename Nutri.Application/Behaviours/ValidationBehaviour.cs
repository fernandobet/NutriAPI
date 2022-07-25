
using FluentValidation;
using MediatR;
using ValidationException = Nutri.Application.Exceptions.ValidationException;

namespace Nutri.Application.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                //Busca todas las validaciones y las ejecuta en el pipe y aqui sabremos si tenemos algun error y si es asi , lo detenemos.
                var validationResults = await Task.WhenAll(_validators.Select(x => x.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(x => x.Errors).Where(x => x != null).ToList();
                //Si hay errores entonces lanzamos la excepcion que elaboramos.
                if (failures.Any())
                    throw new ValidationException(failures);
               
            }
            //Que continue el flujo si no hay errores de validacion.
            return await next();
        }
    }
}
