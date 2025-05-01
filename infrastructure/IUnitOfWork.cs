using domain.Models;
using infrastructure.IRepository;

namespace infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }
        IWarehouseRepository StockRepository { get; }
        ITransactionRepository TransactionRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
