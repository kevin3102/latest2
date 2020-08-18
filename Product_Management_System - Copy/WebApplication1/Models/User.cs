using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Managment_System.Models
{
    public class User
    {
        [Required]
        [Key]
        public string Username { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string SalesOfficeName { get; set; }
        [Required]
        public string Roles { get; set; }
    }
}
