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
        public IEnumerable<OrderDetailView> GetOrderDetailViews()
                    => OrderDetailDAO.Instance.GetOrderDetailViews();

        public OrderDetailView? GetOrderDetailViewByOrderId(int id)
                    => OrderDetailDAO.Instance.GetOrderDetailViewByOrderId(id);
        public IEnumerable<OrderDetail> GetOrderDetailListByOrderId(int orderId)
                    => OrderDetailDAO.Instance.GetOrderDetailListByOrderId(orderId);
    }
}
