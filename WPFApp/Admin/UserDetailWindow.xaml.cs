using BusinessObjects.Models;
using Repositories.UserRepositories;
using System;
using System.Collections.Generic;
using System.Data;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WPFApp.Admin
{
    /// <summary>
    /// Interaction logic for UserDetailWindow.xaml
    /// </summary>
    public partial class UserDetailWindow : Window
    {
        private IUserRepository _userRepository = new UserRepository();
        private UserAccount _selected = null;

        public UserDetailWindow(UserAccount user)
        {
            InitializeComponent();
            if (user != null)
            {
                txtBlockHeader.Text = "UPDATE A USER";
                this.DataContext = user;
                _selected = user;
            }
        }
        private void RoleDetailWindow_Load(object sender, RoutedEventArgs e)
        {
            
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_selected == null)
            {
                UserAccount user = new UserAccount()
                {
                    FullName = txtFullName.Text,
                    DateOfBirth = dpDateOfBirth.SelectedDate ?? DateTime.MinValue,
                    Email = txtEmail.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                    PasswordHash = txtPassword.Text,
                    Status = (UserStatus)cboBoxStatus.SelectedValue,
                    RoleId = Int32.Parse(cboBoxRole.SelectedValue.ToString()),
                };
                _userRepository.AddUser(user);
            }
            else
            {
                try
                {
                    UserAccount user = new UserAccount()
                    {
                        UserId = _selected.UserId,
                        FullName = txtFullName.Text,
                        DateOfBirth = dpDateOfBirth.SelectedDate ?? DateTime.MinValue,
                        Email = txtEmail.Text,
                        PhoneNumber = txtPhoneNumber.Text,
                        PasswordHash = txtPassword.Text,
                        Status = (UserStatus)cboBoxStatus.SelectedValue,
                        RoleId = Int32.Parse(cboBoxRole.SelectedValue.ToString()),
                    };
                    _userRepository.UpdateUser(user);
                    _selected = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}