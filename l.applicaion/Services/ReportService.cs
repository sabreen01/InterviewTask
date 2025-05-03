
using domain.Filters;
using domain.Models;
using infrastructure;
using l.applicaion.DTOs;
using l.applicaion.IServices;
using l.application.DTOs;

namespace l.applicaion.Services
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<TransactionReportDto>> GetTransactionsReport(TransactionHistoryReportFilter filter)
        {
            var transactions = await _unitOfWork.TransactionRepository.GetTransactionsReport(filter);

            var result = transactions.Select(t => new TransactionReportDto
            {
                TransactionId = t.Id,
                Date = t.Date,
                TransactionTypeName = t.TransactionType.Name,
                ProductId = t.ProductId,
                ProductName = t.Product.Name,
                ProductCategory = "", 
                WarehouseId = t.WarehouseId,
                WarehouseName = t.Warehouse.Name,
                Quantity = t.Quantity,
                UserName = t.User.UserName
            }).ToList();

            return result;
        }

        public async Task<List<ProductBelowThresholdDto>> GetProductsBelowThreshould()
        {
            var products = await _unitOfWork.ProductRepository.GetProductsBelowThreshould();

            return products.Select(p => new ProductBelowThresholdDto
            {
                ProductId = p.Id,
                ProductName = p.Name,
                CurrentQuantity = p.Quantity,
                LowStockThreshold = p.LowStockThreshold
            }).ToList();
        }







    }


}
