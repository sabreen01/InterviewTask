using l.applicaion.DTOs;
using l.applicaion.IServices;
using MediatR;

namespace l.applicaion.CQRS.WriteCommands
{
    public record AddStockCommand(StockTransactionDto transaction) : IRequest;

    public class AddStockHandler : IRequestHandler<AddStockCommand>
    {
        private readonly IStockService _service;

        public AddStockHandler(IStockService service)
        {
            _service = service;
        }

        public async Task<Unit> Handle(AddStockCommand request, CancellationToken cancellationToken)
        {
            await _service.AddStock(request.transaction);
            return Unit.Value;
        }
    }
}
