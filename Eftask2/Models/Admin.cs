using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eftask2.Models
{
   public class Admin:BaseEntity
    {
        public string userName { get; set; }
        public string Password { get; set; }
    }
}
