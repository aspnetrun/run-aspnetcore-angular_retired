using AspnetRunAngular.Api.Requests;
using FluentValidation;

namespace AspnetRunAngular.Api.Application.Validations
{
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(request => request.Product).NotNull();
        }
    }
}
