

using domain.Models;
using domain.Filters;
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
            return await _context.Transactions
                .Include(e => e.User)
                .Include(e => e.Product)
                .Include(e => e.TransactionType)
                .Include(e => e.Warehouse)
                .Where(e => !filter.DateFrom.HasValue || e.Date.Date >= filter.DateFrom.Value.Date)
                .Where(e => !filter.DateTo.HasValue || e.Date.Date <= filter.DateTo.Value.Date)
                .Where(e => !filter.ProductId.HasValue || e.ProductId == filter.ProductId)
                .Where(e => !filter.TransactionTypeId.HasValue || e.TransactionTypeId == filter.TransactionTypeId)
                .ToListAsync();
        }

        public async Task<List<Product>> GetProductsBelowThreshould()
        {
            return await _context.Products
                .Where(p => p.Quantity < p.LowStockThreshold)
                .ToListAsync();
        }

    }
}
