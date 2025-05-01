
using domain.Models;
using l.applicaion.DTOs;
using l.applicaion.IServices;
using MediatR;

namespace l.applicaion.CQRS
{
    public record CreateProductCommand(CreateProductDto Product) : IRequest;

    public class CreateProductHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductService _service;

        public CreateProductHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await _service.CreateAsync(request.Product);
            return Unit.Value;
        }
    }

}
