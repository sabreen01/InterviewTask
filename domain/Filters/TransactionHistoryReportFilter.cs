
namespace domain.Dto
{
    public class TransactionHistoryReportFilter
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set;}
        public int? ProductCategory {  get; set; }
        public int? ProductId { get; set;}
    }
}
