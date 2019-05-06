using System.Threading;
using System.Threading.Tasks;
using AspnetRunAngular.Api.Requests;
using AspnetRunAngular.Application.Interfaces;
using AspnetRunAngular.Application.Models;
using MediatR;

namespace AspnetRunAngular.Api.Application.Commands
{
    public class CreateProductCommandHandler
        : IRequestHandler<CreateProductRequest, ProductModel>
    {
        private readonly IProductService _productService;

        public CreateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ProductModel> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var productModel = await _productService.Create(request.Product);

            return productModel;
        }
    }
}
