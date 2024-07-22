using BusinessObjects.Models;
using Repositories.OrderDetailRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFApp.Admin
{
    public class OrderDetailViewModel
    {
        private IOrderDetailRepository _orderDetailRepository = new OrderDetailRepository();
        public OrderDetailView SelectedOrder { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

        public OrderDetailViewModel(OrderDetailView selectedOrder)
        {
            SelectedOrder = selectedOrder;
            OrderDetails = _orderDetailRepository.GetOrderDetailListByOrderId(SelectedOrder.OrderId).ToList();
        }
    }
}
