using AspnetRunAngular.Api.Requests;
using FluentValidation;
using System;

namespace AspnetRunAngular.Api.Application.Validations
{
    public class GetProductsByCategoryIdRequestValidator : AbstractValidator<GetProductsByCategoryIdRequest>
    {
        public GetProductsByCategoryIdRequestValidator()
        {
            RuleFor(request => request.CategoryId).Must(NotEqualToEmptyGuid);
        }

        private bool NotEqualToEmptyGuid(Guid arg)
        {
            return arg != Guid.Empty;
        }
    }
}
