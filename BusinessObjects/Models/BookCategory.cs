using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
    public class BookCategory
    {
        public int BookCategoryId { get; set; }
        public string? BookGenreType { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
