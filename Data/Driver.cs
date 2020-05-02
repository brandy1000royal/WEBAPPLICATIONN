using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebZuber.Data
{
    public class Driver 
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string CarType { get; set; }

        public string Location { get; set; }

    }
}
