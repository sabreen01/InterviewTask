

using domain.Models;
using l.applicaion.DTOs;

namespace l.applicaion.IServices
{
    public interface IStockService
    {
        Task<bool> AddStock(StockTransactionDto stockTransactionDto);
        Task<bool> RemoveStock(StockTransactionDto stockTransactionDto);
        Task<bool> TransferStock(StockTransferDto stockTransactionDto);
    }
}
