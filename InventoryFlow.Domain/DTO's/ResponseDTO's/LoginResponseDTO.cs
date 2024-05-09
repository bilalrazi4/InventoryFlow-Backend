namespace InventoryFlow.Models.DTO_s.ResponseDTO_s
{
    public class LoginResponseDTO
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }

        public List<string> roles { get; set; }

    }
}
