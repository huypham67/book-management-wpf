using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
    public class Publisher
    {
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
