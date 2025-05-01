using l.applicaion.DTOs;
using l.applicaion.IServices;
using MediatR;

namespace l.applicaion.CQRS
{
    public record GetAllWarehouseQuery() : IRequest<IEnumerable<WarehouseDto>>;


    public class GetAllWarehouseHandler : IRequestHandler<GetAllWarehouseQuery, IEnumerable<WarehouseDto>>
    {
        private readonly IWareHouseService _service;

        public GetAllWarehouseHandler(IWareHouseService service)
        {
            _service = service;
        }

        public async Task<IEnumerable<WarehouseDto>> Handle(GetAllWarehouseQuery request, CancellationToken cancellationToken)
        {
            return await _service.GetAllAsync();
        }
    }
}
