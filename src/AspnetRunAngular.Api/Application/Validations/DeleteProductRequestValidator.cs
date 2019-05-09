using AspnetRunAngular.Api.Requests;
using FluentValidation;

namespace AspnetRunAngular.Api.Application.Validations
{
    public class DeleteProductRequestValidator : AbstractValidator<DeleteProductByIdRequest>
    {
        public DeleteProductRequestValidator()
        {
            RuleFor(request => request.Id).GreaterThan(0);
        }
    }
}
