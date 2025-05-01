
using domain.Models;
using l.applicaion.IServices;
using MediatR;

namespace l.applicaion.CQRS
{
    public record GetProductByIdQuery(int Id) : IRequest<Product>;
    public class GetByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductService _service;

        public GetByIdQueryHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<Product?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetByIdAsync(request.Id);
        }
    }
}
