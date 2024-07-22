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

namespace WPFApp.User
{
    /// <summary>
    /// Interaction logic for ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        private IUserRepository _userRepository = new UserRepository();
        private UserAccount _userAccount;
        public ChangePasswordWindow(UserAccount userAccount)
        {
            InitializeComponent();
            if (userAccount != null)
            {
                _userAccount = userAccount;
            }
        }

        private void btnUpdatePassword_Click(object sender, RoutedEventArgs e)
        {
            string currentPassword = passwordBoxCurPass.Password;
            string newPassword = passwordBoxNewPass.Password;
            string confirmNewPassword = passwordBoxConfirmPass.Password;
            bool checkCurrentPassword = (_userAccount.PasswordHash == currentPassword);
            if (!checkCurrentPassword)
            {
                MessageBox.Show("Current password is incorrect.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (currentPassword == newPassword)
            {
                MessageBox.Show("Current password and password is not the same.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (newPassword != confirmNewPassword)
            {
                MessageBox.Show("New passwords do not match.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            _userRepository.ChangePassword(_userAccount.UserId, newPassword);
            MessageBox.Show("Password updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
