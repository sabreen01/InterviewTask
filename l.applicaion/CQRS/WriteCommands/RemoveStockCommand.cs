using l.applicaion.DTOs;
using l.applicaion.IServices;
using MediatR;

namespace l.applicaion.CQRS.WriteCommands
{
     public record RemoveStockCommand(StockTransactionDto transaction) : IRequest;

    public class RemoveStockHandler : IRequestHandler<RemoveStockCommand>
    {
        private readonly IStockService _service;

        public RemoveStockHandler(IStockService service)
        {
            _service = service;
        }

        public async Task<Unit> Handle(RemoveStockCommand request, CancellationToken cancellationToken)
        {
            await _service.RemoveStock(request.transaction);
            return Unit.Value;
        }
    }
}
