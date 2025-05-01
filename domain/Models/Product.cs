using System.ComponentModel.DataAnnotations;

namespace domain.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Quantity {  get; set; }
        public decimal Price { get; set; }
        public int LowStockThreshold { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
