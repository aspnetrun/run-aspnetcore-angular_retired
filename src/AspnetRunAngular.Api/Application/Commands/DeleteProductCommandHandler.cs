using System.Threading;
using System.Threading.Tasks;
using AspnetRunAngular.Api.Requests;
using AspnetRunAngular.Application.Interfaces;
using MediatR;

namespace AspnetRunAngular.Api.Application.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductRequest>
    {
        private readonly IProductService _productService;

        public DeleteProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Unit> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            await _productService.Delete(request.Product);

            return Unit.Value;
        }
    }
}
