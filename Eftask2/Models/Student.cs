using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eftask2.Models
{
    public class Student : BaseEntity
    {
        public int Term { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<S_Cards> S_Cards { get; set; }

    }
}
