﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryFlow.Domain.DTO_s.RegisterationDTO_s
{
    public class UserDetailDTO_s
    {
         public string District { get; set; }
        public string Tehsil { get; set; }   
        public string facility_name { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Hash { get; set; }
        public string Designation { get; set; }


    }
}