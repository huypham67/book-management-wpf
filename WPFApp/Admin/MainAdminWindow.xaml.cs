using BusinessObjects.Models;
using Repositories.BookCategoryRepositories;
using Repositories.BookRepositories;
using Repositories.OrderDetailRepositories;
using Repositories.RoleRepositories;
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

namespace WPFApp.Admin
{
    /// <summary>
    /// Interaction logic for MainAdminWindow.xaml
    /// </summary>
    public partial class MainAdminWindow : Window
    {
        private IBookRepository _bookRepository = new BookRepository();
        private IBookCategoryRepository _bookCategoryRepository = new BookCategoryRepository();
        private IUserRepository _userRepository = new UserRepository();
        private IRoleRepository _roleRepository = new RoleRepository();
        private IOrderDetailRepository _orderDetailViewRepository = new OrderDetailRepository();
        public MainAdminWindow()
        {
            InitializeComponent();
        }
        private void MainAdminWindow_Load(object sender, EventArgs e)
        {
            LoadBookList();
            LoadBookCategoryList();
            LoadUserList();
            LoadRoleList();
            LoadOrderDetailViewList();
        }
        private void LoadBookList()
        {
            dgBookList.ItemsSource = null;
            dgBookList.ItemsSource = _bookRepository.GetBooks().ToList();
            this.DataContext = dgBookList;
        }
        private void LoadBookCategoryList()
        {
            dgBookCategoryList.ItemsSource = null;
            dgBookCategoryList.ItemsSource = _bookCategoryRepository.GetBookCategories().ToList();
            this.DataContext = dgBookCategoryList;
        }
        private void LoadUserList()
        {
            dgUserList.ItemsSource = null;
            dgUserList.ItemsSource = _userRepository.GetUsers().ToList();
            this.DataContext = dgUserList;
        }
        private void LoadRoleList()
        {
            dgRoleList.ItemsSource = null;
            dgRoleList.ItemsSource = _roleRepository.GetRoles().ToList();
            this.DataContext = dgRoleList;
        }
        private void LoadOrderDetailViewList()
        {
            dgOrderDetailViewList.ItemsSource = null;
            dgOrderDetailViewList.ItemsSource = _orderDetailViewRepository.GetOrderDetailDtos().ToList();
            this.DataContext= dgOrderDetailViewList;
        }

        private void btnAddNewBook_Click(object sender, RoutedEventArgs e)
        {
            BookDetailWindow bookDetailWindow = new(null);
            bookDetailWindow.Closed += (s, args) =>
            {
                LoadBookList();
                dgBookList.Items.Refresh();
            };
            bookDetailWindow.ShowDialog();

        }
        private void btnEditBook_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int bookId = (int)button?.CommandParameter;
            Book book = _bookRepository.GetBookById(bookId);
            BookDetailWindow bookDetailWindow = new(book);
            bookDetailWindow.Closed += (s, args) =>
            {
                LoadBookList();
                dgBookList.Items.Refresh();
            };
            bookDetailWindow.ShowDialog();
        }
        private void btnDeleteBook_Click(object sender, RoutedEventArgs e)
        {

            Button button = sender as Button;
            int bookId = (int)button?.CommandParameter;
            Book? book = _bookRepository.GetBookById(bookId);
            MessageBoxResult result = MessageBox.Show($"Do you want to delete book: {book.BookName}?",
                                                      "Confirm Deleting",
                                                      MessageBoxButton.YesNo,
                                                      MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                _bookRepository.DeleteBook(book);
                MessageBox.Show("Delete completely");
                LoadBookList();
                dgBookList.Items.Refresh();
            }
        }
        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            LoginWindow loginWindow = new();
            loginWindow.Show();
        }

        private void btnAddNewRole_Click(object sender, RoutedEventArgs e)
        {
            RoleDetailWindow roleDetailWindow = new(null);
            roleDetailWindow.Closed += (s, args) =>
            {
                LoadBookList();
                dgRoleList.Items.Refresh();
            };
            roleDetailWindow.ShowDialog();
        }
        private void btnEditRole_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int roleId = (int)button?.CommandParameter;
            Role role = _roleRepository.GetRoleById(roleId);
            RoleDetailWindow roleDetailWindow = new(role);
            roleDetailWindow.Closed += (s, args) =>
            {
                LoadRoleList();
                dgRoleList.Items.Refresh();
            };
            roleDetailWindow.ShowDialog();
        }
        private void btnDeleteRole_Click(object sender, RoutedEventArgs e)
        {

            Button button = sender as Button;
            int roleId = (int)button?.CommandParameter;
            Role role = _roleRepository.GetRoleById(roleId);
            MessageBoxResult result = MessageBox.Show($"Do you want to delete role: {role.RoleName}?",
                                                      "Confirm Deleting",
                                                      MessageBoxButton.YesNo,
                                                      MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                _roleRepository.DeleteRole(role);
                MessageBox.Show("Delete completely");
                LoadRoleList();
                dgRoleList.Items.Refresh();
            }
        }
        private void btnAddNewUser_Click(object sender, RoutedEventArgs e)
        {
            UserDetailWindow userDetailWindow = new(null);
            userDetailWindow.Closed += (s, args) =>
            {
                LoadUserList();
                dgUserList.Items.Refresh();
            };
            userDetailWindow.ShowDialog();
        }
        private void btnEditUser_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int userId = (int)button?.CommandParameter;
            UserAccount user = _userRepository.GetUserById(userId);
            UserDetailWindow userDetailWindow = new(user);
            userDetailWindow.Closed += (s, args) =>
            {
                LoadUserList();
                dgUserList.Items.Refresh();
            };
            userDetailWindow.ShowDialog();
        }
        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {

            Button button = sender as Button;
            int userId = (int)button?.CommandParameter;
            UserAccount? user = _userRepository.GetUserById(userId);
            MessageBoxResult result = MessageBox.Show($"Do you want to delete user: {user.FullName}?",
                                                      "Confirm Deleting",
                                                      MessageBoxButton.YesNo,
                                                      MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                _userRepository.DeleteUser(user);
                MessageBox.Show("Delete completely");
                LoadUserList();
                dgUserList.Items.Refresh();
            }
        }
    }
}
