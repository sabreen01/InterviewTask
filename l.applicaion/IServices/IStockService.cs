

using domain.Models;
using l.applicaion.DTOs;

namespace l.applicaion.IServices
{
    public interface IStockService
    {
        Task<bool> AddStock(StockTransactionDto stockTransactionDto, string userId);
        Task<bool> RemoveStock(StockTransactionDto stockTransactionDto, string userId);
        Task<bool> TransferStock(StockTransferDto stockTransactionDto, string userId);
    }
}
