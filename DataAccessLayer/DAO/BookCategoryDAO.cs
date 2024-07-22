using BusinessObjects.Models;
using BusinessObjects;
using DataAccessLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAO
{
    public class BookCategoryDAO : SingletonBase<BookCategoryDAO>
    {
        private BookManagementDbContext _context;
        public IEnumerable<BookCategory> GetBookCategories()
        {
            _context = new();
            return _context.BookCategories;
        }
        public BookCategory? GetBookCategoryById(int id)
        {
            _context = new();
            return _context.BookCategories.FirstOrDefault(b => b.BookCategoryId == id);
        }
        public void AddBookCategory(BookCategory bookCategory)
        {
            _context = new();
            _context.Add(bookCategory);
            _context.SaveChanges();
        }
        public void UpdateBookCategory(BookCategory bookCategory)
        {
            _context = new();
            _context.Update(bookCategory);
            _context.SaveChanges();
        }
        public void DeleteBookCategory(BookCategory bookCategory)
        {
            _context = new();
            _context.Remove(bookCategory);
            _context.SaveChanges();
        }
    }
}
