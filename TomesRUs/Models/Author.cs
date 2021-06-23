using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TomesRUs.Models
{
    public class Author
    {
        public long AuthorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Origin { get; set; }
        public AuthorStatus Status { get; set; }
        public enum AuthorStatus
        {
            Active,
            Retired,
            Deceased
        }
        public ICollection<Book> Books { get; set; }
        public Author()
        {
            //this is a constructor.
        }
    }

    
}
