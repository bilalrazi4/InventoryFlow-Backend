using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryFlow.Domain.DTO_s.ProductDTO_s
{
    public class ProductDTO
    {
        public int? Id { get; set; }
        public required string ProductName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }
    }
}
