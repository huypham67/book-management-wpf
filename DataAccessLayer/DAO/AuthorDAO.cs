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
    public class AuthorDAO : SingletonBase<AuthorDAO>
    {
        private BookManagementDbContext _context;
        public IEnumerable<Author> GetBookAuthors()
        {
            _context = new();
            return _context.Authors;
        }
    }
}
