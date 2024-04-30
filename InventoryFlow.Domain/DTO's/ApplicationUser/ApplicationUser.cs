using Microsoft.AspNetCore.Identity;
namespace InventoryFlow.Domain.DTO_s.ApplicationUser
{
    public class ApplicationUser : IdentityUser
    {
        public string? Hash { get; set; }
        public string? CNIC { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }
        public string? ProfileImage { get; set; }
        public string? Gender { get; set; }
        public int? DivisionCode { get; set; }
        public int? DistrictCode { get; set; }
        public int? TownCode { get; set; }
        public int? InstituteId { get; set; }
        public string? Address { get; set; }
        public string? Designation { get; set; }
        public string? Department { get; set; }
        public bool IsDisabled { get; set; }
        public DateTime? LastLoggedInDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
