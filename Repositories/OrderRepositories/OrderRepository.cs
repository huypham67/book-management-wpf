﻿using BusinessObjects.Models;
using DataAccessLayer.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.OrderRepositories
{
    public class OrderRepository : IOrderRepository
    {
        public void UpdateOrderStatus(int? orderId, OrderStatus newOrderStatus)
                    => OrderDAO.Instance.UpdateOrderStatus(orderId, newOrderStatus);
    }
}
