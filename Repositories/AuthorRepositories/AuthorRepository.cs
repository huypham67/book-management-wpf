using BusinessObjects.Models;
using DataAccessLayer.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.AuthorRepositories
{
    public class AuthorRepository : IAuthorRepository
    {
        public IEnumerable<Author> GetBookAuthors() 
                => AuthorDAO.Instance.GetBookAuthors();
    }
}
