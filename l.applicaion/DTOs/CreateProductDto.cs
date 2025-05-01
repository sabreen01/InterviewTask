
namespace l.applicaion.DTOs
{
    public class CreateProductDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int LowStockThreshold { get; set; }
    }

    public class ProductDto : CreateProductDto
    {
        public int Id { get; set; }
    }
}
