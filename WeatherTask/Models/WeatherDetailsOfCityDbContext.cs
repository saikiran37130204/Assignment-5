using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherDetailsWebAPI.Models
{
    public class WeatherDetailsOfCityDbContext:DbContext
    {
        public WeatherDetailsOfCityDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<WeatherDetailsOfCity> weathers { get; set; }
    }
}
