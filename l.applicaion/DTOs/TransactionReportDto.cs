namespace l.application.DTOs
{
    public class TransactionReportDto
    {
        public int TransactionId { get; set; }
        public DateTime Date { get; set; }
        public string TransactionTypeName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public int Quantity { get; set; }
        public string UserName { get; set; }
    }
}
