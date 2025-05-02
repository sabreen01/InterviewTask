using domain.Dto;
using domain.Models;

namespace l.applicaion.IServices
{
    public interface IReportService
    {
        Task<List<Transaction>> GetTransactionsReport(TransactionHistoryReportFilter filter);
        Task<List<Product>> GetProductsBelowThreshould();
    }
}
