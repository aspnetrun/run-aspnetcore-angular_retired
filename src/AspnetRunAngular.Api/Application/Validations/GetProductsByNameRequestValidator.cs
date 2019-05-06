using AspnetRunAngular.Api.Requests;
using FluentValidation;

namespace AspnetRunAngular.Api.Application.Validations
{
    public class GetProductsByNameRequestValidator : AbstractValidator<GetProductsByNameRequest>
    {
        public GetProductsByNameRequestValidator()
        {
            RuleFor(request => request.Name).NotEmpty();
        }
    }
}
