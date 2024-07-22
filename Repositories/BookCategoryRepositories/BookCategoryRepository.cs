using BusinessObjects.Models;
using DataAccessLayer.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.BookCategoryRepositories
{
    public class BookCategoryRepository : IBookCategoryRepository
    {
        public IEnumerable<BookCategory> GetBookCategories()
                => BookCategoryDAO.Instance.GetBookCategories();
    }
}
