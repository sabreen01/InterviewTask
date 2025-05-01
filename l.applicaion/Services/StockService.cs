using domain.Enums;
using domain.Models;
using infrastructure;
using l.applicaion.DTOs;
using l.applicaion.IServices;

namespace l.applicaion.Services
{
    public class StockService : IStockService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StockService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddStock(StockTransactionDto stockTransactionDto)
        {
            var transaction = new Transaction
            {
                ProductId = stockTransactionDto.ProductId,
                WarehouseId = stockTransactionDto.StockId,
                Quantity = stockTransactionDto.Quantity,
                TransactionTypeId = (int)TransactionTypeEnum.add,
                Date = DateTime.Now,
                UserId = 1,
            };

            await _unitOfWork.TransactionRepository.AddAsync(transaction);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveStock(StockTransactionDto stockTransactionDto)
        {
            var transaction = new Transaction
            {
                ProductId = stockTransactionDto.ProductId,
                WarehouseId = stockTransactionDto.StockId,
                Quantity = stockTransactionDto.Quantity * -1,
                TransactionTypeId = (int)TransactionTypeEnum.remove,
                Date = DateTime.Now,
                UserId = 1,
            };
            await _unitOfWork.TransactionRepository.AddAsync(transaction);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> TransferStock(StockTransferDto stockTransactionDto)
        {
            var removeTransaction = new Transaction
            {
                ProductId = stockTransactionDto.ProductId,
                WarehouseId = stockTransactionDto.FromStockId,
                Quantity = stockTransactionDto.Quantity * -1,
                TransactionTypeId = (int)TransactionTypeEnum.remove,
                Date = DateTime.Now,
                UserId = 1,
            };
            
            var addTransaction = new Transaction
            {
                ProductId = stockTransactionDto.ProductId,
                WarehouseId = stockTransactionDto.ToStockId,
                Quantity = stockTransactionDto.Quantity,
                TransactionTypeId = (int)TransactionTypeEnum.add,
                Date = DateTime.Now,
                UserId = 1,
            };

            await _unitOfWork.TransactionRepository.AddAsync(removeTransaction);
            await _unitOfWork.TransactionRepository.AddAsync(addTransaction);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
