using BusinessObjects.Models;
using DataAccessLayer.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.OrderDetailRepositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public IEnumerable<OrderDetailDto> GetOrderDetailDtos()
                    => OrderDetailDAO.Instance.GetOrderDetailDtos();

    }
}
