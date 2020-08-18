using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Managment_System.Models
{
    public class Product
    {   
        [Required]
        [Key]
     // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Family { get; set; }
        [Required]
        public string Availability { get; set; }
        public string Version { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
