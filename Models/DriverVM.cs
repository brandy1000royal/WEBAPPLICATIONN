using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebZuber.Models
{
    public class DriverVM
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string CarType { get; set; }
        [Required]
        public string Location { get; set; }
    }
}
