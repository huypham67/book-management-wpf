using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string? AuthorName { get; set; }
        public string? Biography { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Nationality { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
