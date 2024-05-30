using InventoryFlow.Domain.DTO_s.StockDto_s;
namespace InventoryFlow.Domain.DTO_s.RequestDto_s
{
    public class CustomApproveRequestDto
    {
        public List<RequestDTO> RequestDetailList { get; set; }
        public List<StockForCustomApproveDto> StockList{ get; set; }

    }
}
