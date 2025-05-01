
namespace l.applicaion.DTOs
{
    public class StockTransactionDto
    {
        public int ProductId { get; set; }
        public int StockId { get; set; }
        public int Quantity { get; set; }
    }

    public class StockTransferDto
    {
        public int ProductId { get; set; }
        public int FromStockId { get; set; }
        public int ToStockId { get; set; }
        public int Quantity { get; set; }
    }
}
