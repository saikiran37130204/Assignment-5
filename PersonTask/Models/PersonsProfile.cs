using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonsProfileMVC.Models
{
    public class PersonsProfile
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string qualification { get; set; }
        public string isEmployed { get; set; }
        public int noticePeriod { get; set; }
        public double currentCTC { get; set; }
    }
}
