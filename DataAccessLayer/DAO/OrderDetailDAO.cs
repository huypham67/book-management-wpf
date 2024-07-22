using BusinessObjects;
using BusinessObjects.Models;
using DataAccessLayer.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DAO
{
    public class OrderDetailDAO : SingletonBase<OrderDetailDAO>
    {
        private BookManagementDbContext _context;
        public IEnumerable<OrderDetailView> GetOrderDetailViews()
        {
            _context = new();
            var orderDetails = _context.Orders
                .Join(_context.OrderDetails,
                    o => o.OrderId,
            od => od.OrderId,
                    (o, od) => new { o, od })
                .Join(_context.Users,
                    oo => oo.o.UserId,
                    u => u.UserId,
                    (oo, u) => new { oo.o, oo.od, u })
                .GroupBy(x => new { x.o.OrderId, x.o.OrderDate, x.u.FullName, x.o.OrderStatus })
                .Select(g => new OrderDetailView
                {
                    OrderId = g.Key.OrderId,
                    OrderDate = g.Key.OrderDate,
                    CustomerName = g.Key.FullName,
                    Quantity = g.Sum(x => x.od.Quantity),
                    TotalPrice = g.Sum(x => x.od.Quantity * x.od.UnitPrice),
                    OrderStatus = g.Key.OrderStatus
                })
                .ToList();

            return orderDetails;
        }
        public IEnumerable<OrderDetail> GetOrderDetailListByOrderId(int? orderId)
        {
            _context = new();
            return _context.OrderDetails
                    .Include(od => od.Book) // Include related Book details
                    .Where(od => od.OrderId == orderId);
        }
        public OrderDetailView? GetOrderDetailViewByOrderId(int? id)
        {
            _context = new();
            var orderDetail = _context.Orders
                .Where(o => o.OrderId == id)
                .Join(_context.OrderDetails,
                    o => o.OrderId,
                    od => od.OrderId,
                    (o, od) => new { o, od })
                .Join(_context.Users,
                    oo => oo.o.UserId,
                    u => u.UserId,
                    (oo, u) => new { oo.o, oo.od, u })
                .GroupBy(x => new { x.o.OrderId, x.o.OrderDate, x.u.FullName, x.o.OrderStatus })
                .Select(g => new OrderDetailView
                {
                    OrderId = g.Key.OrderId,
                    OrderDate = g.Key.OrderDate,
                    CustomerName = g.Key.FullName,
                    Quantity = g.Sum(x => x.od.Quantity),
                    TotalPrice = g.Sum(x => x.od.Quantity * x.od.UnitPrice),
                    OrderStatus = g.Key.OrderStatus
                })
                .FirstOrDefault();

            return orderDetail;
        }
    }
}
