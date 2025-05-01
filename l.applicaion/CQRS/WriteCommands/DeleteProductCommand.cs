
using l.applicaion.DTOs;
using l.applicaion.IServices;
using MediatR;

namespace l.applicaion.CQRS.WriteCommands
{
    public record DeleteProductCommand(int productId) : IRequest;
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductService _service;

        public DeleteProductHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _service.DeleteAsync(request.productId);
            return Unit.Value;
        }
    }
}
