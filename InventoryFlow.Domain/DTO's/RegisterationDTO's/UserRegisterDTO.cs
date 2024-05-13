using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryFlow.Domain.DTO_s.RegisterationDTO_s
{
    public class UserRegisterDTO
    {
        public string? Username { get; set; }
        public string? Email { get; set; }

        public string? Password { get; set; }
        public string? DistrictCode { get; set; }
        public string? TownCode { get; set; }
        public string? InstituteId { get; set; }
        public string? Designation { get; set; }
        public bool? IsDisabled { get; set; }
        public string? CNIC { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNo { get; set; }
    }
}
