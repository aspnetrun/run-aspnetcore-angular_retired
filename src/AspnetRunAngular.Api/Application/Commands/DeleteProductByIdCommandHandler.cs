using System.Threading;
using System.Threading.Tasks;
using AspnetRunAngular.Api.Requests;
using AspnetRunAngular.Application.Interfaces;
using MediatR;

namespace AspnetRunAngular.Api.Application.Commands
{
    public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdRequest>
    {
        private readonly IProductService _productService;

        public DeleteProductByIdCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Unit> Handle(DeleteProductByIdRequest request, CancellationToken cancellationToken)
        {
            await _productService.DeleteProductById(request.Id);

            return Unit.Value;
        }
    }
}
