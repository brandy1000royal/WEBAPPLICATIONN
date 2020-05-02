using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebZuber.Data
{
    public class ZuberStaff : IdentityUser
    {
        public string Name { get; set; }
        public string Position { get; set; }
    }
}
