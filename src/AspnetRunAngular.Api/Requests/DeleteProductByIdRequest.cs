using MediatR;

namespace AspnetRunAngular.Api.Requests
{
    public class DeleteProductByIdRequest : IRequest
    {
        public int Id { get; set; }
    }
}
