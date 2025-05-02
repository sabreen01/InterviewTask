using domain.Dto;
using domain.Models;
using infrastructure;
using l.applicaion.IServices;

namespace l.applicaion.Services
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Transaction>> GetTransactionsReport(TransactionHistoryReportFilter filter)
        {
           return await _unitOfWork.TransactionRepository.GetTransactionsReport(filter);
        }

        public async Task<List<Product>> GetProductsBelowThreshould()
        {
            return await _unitOfWork.ProductRepository.GetProductsBelowThreshould();
        }
    }
}
