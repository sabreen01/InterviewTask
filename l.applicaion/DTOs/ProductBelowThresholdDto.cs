using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l.applicaion.DTOs
{
    public class ProductBelowThresholdDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CurrentQuantity { get; set; }
        public int LowStockThreshold { get; set; }
    }
}
