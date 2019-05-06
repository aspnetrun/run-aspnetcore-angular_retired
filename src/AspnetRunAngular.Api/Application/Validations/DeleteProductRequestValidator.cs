using AspnetRunAngular.Api.Requests;
using FluentValidation;

namespace AspnetRunAngular.Api.Application.Validations
{
    public class DeleteProductRequestValidator : AbstractValidator<DeleteProductRequest>
    {
        public DeleteProductRequestValidator()
        {
            RuleFor(request => request.Product).NotNull();
        }
    }
}
