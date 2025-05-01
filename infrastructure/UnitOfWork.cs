using domain.Models;
using infrastructure.Db;
using infrastructure.IRepository;
using infrastructure.Repository;

namespace infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IProductRepository _productRepository;
        private readonly IWarehouseRepository _stockRepository;
        private readonly ITransactionRepository _transactionRepository;

        public UnitOfWork(AppDbContext context,
                          IProductRepository productRepository,
                          IWarehouseRepository stockRepository,
                          ITransactionRepository transactionRepository)
        {
            _context = context;
            _productRepository = productRepository;
            _stockRepository = stockRepository;
            _transactionRepository = transactionRepository;
        }

        public IProductRepository ProductRepository =>
            _productRepository;

        public IWarehouseRepository StockRepository => _stockRepository;

        public ITransactionRepository TransactionRepository => _transactionRepository;

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }

}
