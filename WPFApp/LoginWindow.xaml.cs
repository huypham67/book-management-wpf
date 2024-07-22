using Repositories.AdminRepositories;
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
using WPFApp.User;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private IUserRepository _userRepository = new UserRepository();
        private IAdminRepository _adminRepository = new AdminRepository();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Password;
            //check Admin Login
            bool isAdmin = _adminRepository.GetAdminAccount(email, password);
            if (isAdmin)
            {
                this.Hide();
                MainAdminWindow mainAdminWindow = new();
                mainAdminWindow.Show();
                return;
            }

            var acc = _userRepository.CheckLogin(email, password);
            if (acc == null)
            {
                MessageBox.Show("Login failed. Check the email and password again!", "Wrong credentials", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (acc.RoleId != 1)
            {
                MessageBox.Show("You have no permission to access this function!", "Wrong privilege", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            this.Hide();
            UserWindow userWindow = new(acc);
            userWindow.Show();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
