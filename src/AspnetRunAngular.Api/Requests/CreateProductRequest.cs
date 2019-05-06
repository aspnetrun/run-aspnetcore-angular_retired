using AspnetRunAngular.Application.Models;
using MediatR;

namespace AspnetRunAngular.Api.Requests
{
    public class CreateProductRequest : IRequest<ProductModel>
    {
        public ProductModel Product { get; set; }
    }
}
