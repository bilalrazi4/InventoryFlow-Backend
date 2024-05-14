using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryFlow.Domain.DTO_s.LoginDTO_s
{
    public class UserLoginDTO
    {

        [Required(ErrorMessage = "User Name is required")]
    
        public required string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public required string Password { get; set; }

        

    }
}
