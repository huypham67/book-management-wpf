using BusinessObjects.Models;
using DataAccessLayer.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.PublisherRepositories
{
    public class PublisherRepository : IPublisherRepository
    {
        public IEnumerable<Publisher> GetBookPublishers()
                    => PublisherDAO.Instance.GetBookPublishers();
    }
}
