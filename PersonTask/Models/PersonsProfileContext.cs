using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonsProfileMVC.Models
{
    
        public class PersonsProfileContext : DbContext
        {
        public PersonsProfileContext() : base()
        {

        }
        public PersonsProfileContext(DbContextOptions options) : base(options)
            {

            }
            public DbSet<PersonsProfile> persons { get; set; }

        }
}
