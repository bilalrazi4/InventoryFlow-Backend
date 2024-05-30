using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryFlow.Domain.DTO_s.RequestDto_s
{
    public class RequestDTO
    {
        public int Id { get; set; }
        public string? AdminId { get; set; }
        public int StockId { get; set; }
        public int ProductId { get; set; }
        public decimal RequestedQuantity { get; set; }
        public decimal UpdatedQuantity { get; set; }
        public decimal PricePerUnit { get; set; }
        public decimal TotalPrice { get; set; }
        public string? Remarks { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsActive { get; set; }
        public int RequestId { get; set; }
    }
}
