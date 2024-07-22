using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.OrderDetailRepositories
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetailView> GetOrderDetailViews();
        OrderDetailView? GetOrderDetailViewByOrderId(int id);
        IEnumerable<OrderDetail> GetOrderDetailListByOrderId(int orderId);
    }
}
