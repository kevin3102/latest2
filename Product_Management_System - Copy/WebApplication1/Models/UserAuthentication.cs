﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Managment_System.Models
{
    public class UserAuthentication
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
     
    }
}
