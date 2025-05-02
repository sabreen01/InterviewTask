
using domain.Dto;
using domain.Models;

namespace infrastructure.IRepository
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
        Task<List<Transaction>> GetTransactionsReport(TransactionHistoryReportFilter filter);
    }
}
