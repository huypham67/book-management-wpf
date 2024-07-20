using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string? BookName { get; set; }
        public string? BookDescription { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int AuthorId { get; set; }
        public int BookCategoryId { get; set; }
        public int PublisherId { get; set; }
        public virtual Author? Author { get; set; }
        public virtual BookCategory? BookCategory { get; set; }
        public virtual Publisher? Publisher { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
