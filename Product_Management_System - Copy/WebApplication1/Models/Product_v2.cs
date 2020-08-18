using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Product_Managment_System.Models
{
    public class Product_v2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
