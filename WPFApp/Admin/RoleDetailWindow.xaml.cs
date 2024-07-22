using BusinessObjects.Models;
using Repositories.RoleRepositories;
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
    /// Interaction logic for RoleDetailWindow.xaml
    /// </summary>
    public partial class RoleDetailWindow : Window
    {
        private IRoleRepository _roleRepository = new RoleRepository();
        private Role _selected = null;
        public RoleDetailWindow(Role role)
        {
            InitializeComponent();
            if (role != null)
            {
                txtBlockHeader.Text = "UPDATE A ROLE";
                this.DataContext = role;
                _selected = role;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_selected == null)
            {
                Role role = new Role()
                {
                    RoleName = txtRoleName.Text,
                    RoleDescription = txtRoleDescription.Text
                };
                _roleRepository.AddRole(role);
            }
            else
            {
                try
                {
                    Role role = new Role()
                    {
                        RoleId = _selected.RoleId,
                        RoleName = txtRoleName.Text,
                        RoleDescription = txtRoleDescription.Text
                    };
                    _roleRepository.UpdateRole(role);
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
