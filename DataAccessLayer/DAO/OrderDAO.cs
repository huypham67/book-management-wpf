using BusinessObjects;
using BusinessObjects.Models;
using DataAccessLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAO
{
    public class OrderDAO : SingletonBase<OrderDAO>
    {
        private BookManagementDbContext _context;
        public void UpdateOrderStatus(int? orderId, OrderStatus newOrderStatus)
        {
            _context = new();
            var order = _context.Orders.Find(orderId);
            if (order != null && order.OrderStatus != newOrderStatus)
            {
                order.OrderStatus = newOrderStatus;
                _context.SaveChanges();
            }
            
        }
    }
}
