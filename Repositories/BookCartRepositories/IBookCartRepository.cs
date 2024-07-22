using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.BookCartRepositories
{
    public interface IBookCartRepository
    {
        IEnumerable<BookCart> GetBookCarts();
        void AddBookToCart(BookCart bookCart);
        BookCart? CheckExistedInCart(int id);
    }
}
