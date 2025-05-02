
using domain.Dto;
using domain.Models;
using infrastructure.Db;
using infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace infrastructure.Repository
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        private readonly AppDbContext _context;

        public TransactionRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Transaction>> GetTransactionsReport(TransactionHistoryReportFilter filter)
        {
            return await _context.Transactions.Include(r=>r.User)
                                              .Where(e => (!filter.DateFrom.HasValue||e.Date.Date>= filter.DateFrom.Value.Date))
                                              .Where(e=>  (!filter.DateTo.HasValue || e.Date.Date <= filter.DateTo.Value.Date))
                                              .Where(e => (!filter.ProductId.HasValue || e.ProductId <= filter.ProductId))
                                              .ToListAsync();
        }

    }
}
