using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryFlow.Domain.DTO_s.StockDto_s
{
    public class StockForUserDTO
    {
        public int ProudctId { get; set; }
        public string ProductName{ get; set; }
        public decimal TotalQty { get; set; }
        public decimal PricePerUnit { get; set; }

    }
}
