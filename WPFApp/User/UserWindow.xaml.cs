using BusinessObjects.Models;
using Repositories.UserRepositories;
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
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private IUserRepository _userRepository = new UserRepository();
        private UserAccount _userAccount;
        public UserWindow(UserAccount userAccount)
        {
            InitializeComponent();
            _userAccount = userAccount;
            this.DataContext = _userAccount;
        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            ChangePasswordWindow changePasswordWindow = new(_userAccount);
            MessageBox.Show(_userAccount.PasswordHash);
            changePasswordWindow.ShowDialog();
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            LoginWindow loginWindow = new();
            loginWindow.Show();
        }

        private void btnUpdateProfile_Click(object sender, RoutedEventArgs e)
        {
            EnableProfileFields(true);
            UserAccount userAccount = new UserAccount()
            {
                UserId = _userAccount.UserId,
                FullName = txtFullName.Text,
                DateOfBirth = dpDateOfBirth.SelectedDate ?? DateTime.MinValue,
                PhoneNumber = txtPhoneNumber.Text,
                Email = txtEmail.Text
            };
            _userRepository.UpdateUser(userAccount);
            EnableProfileFields(false);
        }
        private void EnableProfileFields(bool isEnable)
        {
            txtFullName.IsEnabled = isEnable;
            dpDateOfBirth.IsEnabled = isEnable;
            txtPhoneNumber.IsEnabled = isEnable;
            txtEmail.IsEnabled = isEnable;
        }
        private void btnViewOrderHistoryDetail_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int orderId = (int)button?.CommandParameter;
            OrderDetailWindow orderDetailWindow = new(orderId);
            orderDetailWindow.ShowDialog();
        }
    }
}
