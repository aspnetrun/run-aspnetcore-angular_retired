using AspnetRunAngular.Api.Requests;
using FluentValidation;

namespace AspnetRunAngular.Api.Application.Validations
{
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductRequestValidator()
        {
            RuleFor(request => request.Product).NotNull();
        }
    }
}
