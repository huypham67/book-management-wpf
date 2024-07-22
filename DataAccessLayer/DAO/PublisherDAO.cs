using BusinessObjects.Models;
using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Common;

namespace DataAccessLayer.DAO
{
    public class PublisherDAO : SingletonBase<PublisherDAO>
    {
        private BookManagementDbContext _context;
        public IEnumerable<Publisher> GetBookPublishers()
        {
            _context = new();
            return _context.Publishers;
        }
    }
}
