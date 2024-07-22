using BusinessObjects;
using BusinessObjects.Models;
using DataAccessLayer.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAO
{
    public class BookCartDAO : SingletonBase<BookCartDAO>
    {
        private BookManagementDbContext _context;
        public IEnumerable<BookCart> GetBookCarts()
        {
            _context = new();
            return _context.BookCarts;
        }
        public void AddBookToCart(BookCart bookCart)
        {
            _context = new();
            _context.Add(bookCart);
            _context.SaveChanges();
        }
        public BookCart? CheckExisted(int id)
        {
            _context = new();
            return _context.BookCarts.SingleOrDefault(book => book.BookId == id);
        }
    }
}
