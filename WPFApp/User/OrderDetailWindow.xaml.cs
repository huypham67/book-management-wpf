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
using WPFApp.Admin;

namespace WPFApp.User
{
    /// <summary>
    /// Interaction logic for OrderDetailWindow.xaml
    /// </summary>
    public partial class OrderDetailWindow : Window
    {
        private IOrderRepository _orderRepository = new OrderRepository();
        private IOrderDetailRepository _orderDetailRepository = new OrderDetailRepository();
        private int? _selectedOrderId = null;
        public OrderDetailWindow(int orderId)
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

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
