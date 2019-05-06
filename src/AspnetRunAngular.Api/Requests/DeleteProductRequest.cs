using AspnetRunAngular.Application.Models;
using MediatR;

namespace AspnetRunAngular.Api.Requests
{
    public class DeleteProductRequest : IRequest
    {
        public ProductModel Product { get; set; }
    }
}
