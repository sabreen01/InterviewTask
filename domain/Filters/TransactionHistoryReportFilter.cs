
using domain.Enums;

namespace domain.Filters
{
    public class TransactionHistoryReportFilter
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? ProductCategory { get; set; }
        public int? ProductId { get; set; }
        public TransactionTypeEnum? TransactionType { get; set; }
        public int? TransactionTypeId { get; set; }





    }
}
