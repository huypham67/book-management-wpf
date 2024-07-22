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
    }
}
