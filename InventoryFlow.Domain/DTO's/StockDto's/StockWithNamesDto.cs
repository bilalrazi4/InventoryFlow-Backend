using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryFlow.Domain.DTO_s.StockDto_s
{
    public class StockWithNamesDto
    {
        public int StockId { get; set; }
        public string ProductName{ get; set; }
        public string VendorName{ get; set; }
        public string CategoryName { get; set; }
        public decimal Rate { get; set; }
        public decimal Quantity { get; set; }
        public string? Batch { get; set; }
        public DateTime? ManufacturingDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool InStock { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
