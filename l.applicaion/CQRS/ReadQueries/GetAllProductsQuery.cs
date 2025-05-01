using domain.Models;
using l.applicaion.IServices;
using MediatR;

namespace l.applicaion.CQRS
{
    public record GetAllProductsQuery() : IRequest<IEnumerable<Product>>;


    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductService _service;
       
        public GetAllProductsHandler(IProductService service)
        {
            _service = service;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetAllAsync();
        }
    }

}
