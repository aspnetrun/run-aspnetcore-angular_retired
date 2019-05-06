using AspnetRunAngular.Api.Requests;
using FluentValidation;
using System;

namespace AspnetRunAngular.Api.Application.Validations
{
    public class GetProductByIdRequestValidator : AbstractValidator<GetProductByIdRequest>
    {
        public GetProductByIdRequestValidator()
        {
            RuleFor(request => request.Id).Must(NotEqualToEmptyGuid);
        }

        private bool NotEqualToEmptyGuid(Guid arg)
        {
            return arg != Guid.Empty;
        }
    }
}
