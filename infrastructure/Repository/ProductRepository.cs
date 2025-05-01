using domain.Models;
using infrastructure.Db;
using infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Repository
{
    public class ProductRepository : GenericRepository<Product>,IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context):base(context)
        {
            _context = context;
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Product>> GetProductsBelowThreshould()
        {
           return await _context.Products.Where(e=>e.Transactions.Sum(f=>f.Quantity)<e.LowStockThreshold).ToListAsync();
        }
    }

}
