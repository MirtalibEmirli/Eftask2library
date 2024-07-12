using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eftask2.Models
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public int Pages { get; set; }
        public int YearPress { get; set; }
        public int IdCategory { get; set; }
        public int IdAuthor { get; set; }
        public int Quantity { get; set; }
        public Author Author { get; set; }
        public Category Category { get; set; }
        public List<S_Cards> S_Cards { get; set; }

    }
}
