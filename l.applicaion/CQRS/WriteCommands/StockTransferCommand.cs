

using l.applicaion.DTOs;
using l.applicaion.IServices;
using MediatR;

namespace l.applicaion.CQRS.WriteCommands
{
    public record StockTransferCommand(StockTransferDto transaction, string userId) : IRequest;

    public class StockTransferHandler : IRequestHandler<StockTransferCommand>
    {
        private readonly IStockService _service;

        public StockTransferHandler(IStockService service)
        {
            _service = service;
        }

        public async Task<Unit> Handle(StockTransferCommand request, CancellationToken cancellationToken)
        {
            await _service.TransferStock(request.transaction, request.userId);
            return Unit.Value;
        }
    }
}
