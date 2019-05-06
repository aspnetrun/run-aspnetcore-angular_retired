using AspnetRunAngular.Application.Models;
using MediatR;

namespace AspnetRunAngular.Api.Requests
{
    public class UpdateProductRequest : IRequest
    {
        public ProductModel Product { get; set; }
    }
}
