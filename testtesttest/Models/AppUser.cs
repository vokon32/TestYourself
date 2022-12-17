using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testtesttest.Models
{
    public class AppUser
    {
        [Key]
        public string Id { get; set; }
        public int? Pace { get; set; }
        public int? Meliage { get; set; }

    }
}
