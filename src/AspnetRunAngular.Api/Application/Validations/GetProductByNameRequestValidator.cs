using AspnetRunAngular.Api.Requests;
using FluentValidation;

namespace AspnetRunAngular.Api.Application.Validations
{
    public class GetProductByNameRequestValidator : AbstractValidator<GetProductByNameRequest>
    {
        public GetProductByNameRequestValidator()
        {
            RuleFor(request => request.Name).NotEmpty();
        }
    }
}
