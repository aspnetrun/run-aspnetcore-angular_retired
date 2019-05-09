using AspnetRunAngular.Api.Requests;
using FluentValidation;

namespace AspnetRunAngular.Api.Application.Validations
{
    public class GetProductsByCategoryIdRequestValidator : AbstractValidator<GetProductsByCategoryIdRequest>
    {
        public GetProductsByCategoryIdRequestValidator()
        {
            RuleFor(request => request.CategoryId).GreaterThan(0);
        }
    }
}
