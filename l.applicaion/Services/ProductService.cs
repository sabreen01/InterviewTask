using domain.Models;
using infrastructure;
using l.applicaion.DTOs;
using l.applicaion.IServices;

namespace l.applicaion.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<Product>> GetAllAsync() => _unitOfWork.ProductRepository.GetAllAsync();
        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _unitOfWork.ProductRepository.GetByIdAsync(id);
        }
        public async Task<bool> CreateAsync(CreateProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Description = productDto.Description,
                Price = productDto.Price,
                Quantity = productDto.Quantity,
                LowStockThreshold = productDto.LowStockThreshold,
            };
            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task UpdateAsync(ProductDto productDto)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(productDto.Id);

            if (product != null)
            {
                product.Name = productDto.Name;
                product.Description = productDto.Description;
                product.Price = productDto.Price;
                product.Quantity = productDto.Quantity;
                product.LowStockThreshold = productDto.LowStockThreshold;

                await _unitOfWork.ProductRepository.UpdateAsync(product);
                await _unitOfWork.SaveChangesAsync();
            }
        }
        public async Task DeleteAsync(int id)
        { 
          await  _unitOfWork.ProductRepository.DeleteAsync(id);
        }
    }

}
