
using domain.Models;
using infrastructure.Db;
using infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Repository
{
    public class WarehouseRepository : GenericRepository<Warehouse>, IWarehouseRepository
    {
        private readonly AppDbContext _context;

        public WarehouseRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
