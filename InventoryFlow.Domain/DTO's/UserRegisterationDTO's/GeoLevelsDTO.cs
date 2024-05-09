using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace InventoryFlow.Domain.DTO_s.UserRegisterationDTO_s
{
    public class GeoLevelsDTO
    {
        public int Id { get; set; }
        public string PKCODE { get; set; }
        public string FKCODE { get; set; }
        public string CODE { get; set; }
        public string NAME { get; set; }
        public string LVL { get; set; }
    }
}
