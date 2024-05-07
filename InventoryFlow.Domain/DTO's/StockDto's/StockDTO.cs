using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryFlow.Domain.DTO_s.StockDto_s
{
    public class StockDTO
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int VendorId { get; set; }

        public int CategoryId { get; set; }

        public string? Batch { get; set; }

        public decimal? Quantity { get; set; }

        public decimal? Rate { get; set; }

        public DateTime? ManufacturingDate { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string? UpdatedBy { get; set; }

        public bool? IsActive { get; set; }
        public bool InStock { get; set; }

    }
}
