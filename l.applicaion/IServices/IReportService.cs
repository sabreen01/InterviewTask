
using domain.Filters;
using l.applicaion.DTOs;
using l.application.DTOs;


namespace l.applicaion.IServices
{
    public interface IReportService
    {
        Task<List<ProductBelowThresholdDto>> GetProductsBelowThreshould();
        Task<List<TransactionReportDto>> GetTransactionsReport(TransactionHistoryReportFilter filter);
    }
}
