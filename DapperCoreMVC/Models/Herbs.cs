using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DapperCoreMVC.Models
{
    public class Herbs
    {
        [Key]
        public int HerbId { get; set; }
        [Required]
        [Display(Name="Název")]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Popis")]
        public string Info { get; set; }
        [Required]
        [Display(Name = "Léčivé účinky")]
        public string Healing { get; set; }
    }
}
