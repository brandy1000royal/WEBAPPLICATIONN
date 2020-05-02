using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebZuber.Data;
using WebZuber.Models;

namespace WebZuber.Mappings
{
    public class Maps:Profile
    {
        public Maps()
        {
            CreateMap<Ride, RideVM>().ReverseMap();
            CreateMap<Driver, DriverVM>().ReverseMap();
           
        }
    }
}
