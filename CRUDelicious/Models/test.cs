using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDelicious.Models
{
    public class test
    {
        [Key]
       public int userid { get; set; }
       public string content { get; set; }

        public test(string content)
        { this.content = content; }
    }
}
