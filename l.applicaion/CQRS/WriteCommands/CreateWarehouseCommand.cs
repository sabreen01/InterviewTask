using l.applicaion.DTOs;
using l.applicaion.IServices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l.applicaion.CQRS
{

    public record CreateWarehouseCommand(WarehouseDto warehouse) : IRequest;

    public class CreateWarehouseHandler : IRequestHandler<CreateWarehouseCommand>
    {
        private readonly IWareHouseService _service;

        public CreateWarehouseHandler(IWareHouseService service)
        {
            _service = service;
        }

        public async Task<Unit> Handle(CreateWarehouseCommand request, CancellationToken cancellationToken)
        {
            await _service.CreateAsync(request.warehouse);
            return Unit.Value;
        }
    }
}
