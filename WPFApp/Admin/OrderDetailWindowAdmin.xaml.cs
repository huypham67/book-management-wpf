using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Repositories.OrderDetailRepositories;
using Repositories.OrderRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFApp.Admin
{
    /// <summary>
    /// Interaction logic for OrderDetailWindowAdmin.xaml
    /// </summary>
    public partial class OrderDetailWindowAdmin : Window
    {
        private IOrderRepository _orderRepository = new OrderRepository();
        private IOrderDetailRepository _orderDetailRepository = new OrderDetailRepository();
        private int? _selectedOrderId = null;
        public OrderDetailWindowAdmin(int orderId)
        {
            InitializeComponent();
            if (orderId != null)
            {
                var orderDetailView = _orderDetailRepository.GetOrderDetailViewByOrderId(orderId);
                if (orderDetailView != null)
                {
                    _selectedOrderId = orderId;
                    DataContext = new OrderDetailViewModel(orderDetailView);
                }
            }
        }
        private void OrderDetailWindowAdmin_Load(object sender, EventArgs e)
        {
            LoadOrderStatus();
        }
        private void LoadOrderStatus()
        {
            cboBoxOrderStatus.ItemsSource = null;
            cboBoxOrderStatus.ItemsSource = Enum.GetValues(typeof(OrderStatus)).Cast<OrderStatus>().ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            OrderStatus newOrderStatus = (OrderStatus)cboBoxOrderStatus.SelectedValue;
            if (_selectedOrderId != null)
            {
                _orderRepository.UpdateOrderStatus(_selectedOrderId, newOrderStatus);
            }
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
