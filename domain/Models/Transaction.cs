
using domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace domain.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TransactionTypeId { get; set; }
        [ForeignKey("TransactionTypeId")]
        public TransactionType TransactionType { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        
        public int WarehouseId { get; set; }
        [ForeignKey("WarehouseId")]
        public virtual Warehouse Warehouse { get; set; }
        public int Quantity { get; set; }
        public int? UserId { get; set; }
    }
}
