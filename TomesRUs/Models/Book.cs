using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TomesRUs.Models
{
    public class Book
    {
        public long ID { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public int ReleasedDate { get; set; }
        [ForeignKey("Author")]
        public long AuthorID { get; set; }
        public Author Author { get; set; }
        public Book()
        {
            //This is a constructor.
        }
    }

    
}
