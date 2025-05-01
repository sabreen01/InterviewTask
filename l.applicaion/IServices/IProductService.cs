using domain.Models;
using l.applicaion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l.applicaion.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateProductDto productDto);
        Task UpdateAsync(ProductDto productDto);
        Task DeleteAsync(int id);
    }
}
