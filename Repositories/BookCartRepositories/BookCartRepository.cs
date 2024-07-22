using BusinessObjects.Models;
using DataAccessLayer.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.BookCartRepositories
{
    public class BookCartRepository : IBookCartRepository
    {
        public IEnumerable<BookCart> GetBookCarts()
                    => BookCartDAO.Instance.GetBookCarts();
        public void AddBookToCart(BookCart bookCart)
                    => BookCartDAO.Instance.AddBookToCart(bookCart);
        public BookCart? CheckExistedInCart(int id)
                    => BookCartDAO.Instance.CheckExisted(id);
    }
}
