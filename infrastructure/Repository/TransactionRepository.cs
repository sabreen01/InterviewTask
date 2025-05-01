
using domain.Models;
using infrastructure.Db;
using infrastructure.IRepository;

namespace infrastructure.Repository
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        private readonly AppDbContext _context;

        public TransactionRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
