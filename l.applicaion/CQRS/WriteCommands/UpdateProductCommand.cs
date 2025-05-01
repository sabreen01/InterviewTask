using l.applicaion.DTOs;
using l.applicaion.IServices;
using MediatR;

namespace l.applicaion.CQRS.WriteCommands
{
    public record UpdateProductCommand(ProductDto Product) : IRequest;

    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductService _service;

        public UpdateProductHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            await _service.UpdateAsync(request.Product);
            return Unit.Value;
        }
    }
}
