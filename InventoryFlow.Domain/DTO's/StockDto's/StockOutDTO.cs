using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryFlow.Domain.DTO_s.StockDto_s
{
    public class StockOutDTO
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public int CategoryId { get; set; }
        public int RequestMasterId { get; set; }
        public string Batch { get; set; } = null!;
        public decimal RequestedQuantity { get; set; }
        public decimal ApprovedQuantity { get; set; }
        public decimal Rate { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
    }
}
