using domain.Models;
using domain.Filters;


namespace infrastructure.IRepository
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
        Task<List<Transaction>> GetTransactionsReport(TransactionHistoryReportFilter filter);
        Task<List<Product>> GetProductsBelowThreshould();
    }
}
