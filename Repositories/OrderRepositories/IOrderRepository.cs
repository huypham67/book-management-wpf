using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.OrderRepositories
{
    public interface IOrderRepository
    {
        void UpdateOrderStatus(int? orderId, OrderStatus newOrderStatus);
    }
}
