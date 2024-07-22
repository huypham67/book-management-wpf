using BusinessObjects.Models;
using Repositories.BookCartRepositories;
using Repositories.BookRepositories;
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
        private IBookRepository _bookRepository = new BookRepository();
        private IUserRepository _userRepository = new UserRepository();
        private IBookCartRepository _bookCartRepository = new BookCartRepository();
        private UserAccount _userAccount;
        public UserWindow(UserAccount userAccount)
        {
            InitializeComponent();
            _userAccount = userAccount;
            this.DataContext = _userAccount;
        }
        private void UserWindow_Load(object sender, RoutedEventArgs e)
        {
            LoadBookList();
            LoadBookCartList();
        }
        private void LoadBookList()
        {
            dgAllBooks.ItemsSource = null;
            dgAllBooks.ItemsSource = _bookRepository.GetBooks().ToList();
        }
        private void LoadBookCartList()
        {
            dgBookCart.ItemsSource = null;
            dgBookCart.ItemsSource = _bookCartRepository.GetBookCarts().ToList();
        }

        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            ChangePasswordWindow changePasswordWindow = new(_userAccount);
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
            if (txtFullName.IsEnabled == false)
            {
                EnableProfileFields(true);
            }
            else
            {
                try
                {
                    UserAccount userAccount = new UserAccount()
                    {
                        UserId = _userAccount.UserId,
                        FullName = txtFullName.Text,
                        DateOfBirth = dpDateOfBirth.SelectedDate ?? DateTime.MinValue,
                        PhoneNumber = txtPhoneNumber.Text,
                        Email = txtEmail.Text
                    };
                    _userRepository.UpdateUser(userAccount);
                    MessageBox.Show("Update successfully");
                    EnableProfileFields(false);
                }
                catch (Exception ex) 
                {
                    MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
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
        private void btnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int bookId = (int)button?.CommandParameter;
            Book? book = _bookRepository.GetBookById(bookId);
            if (book != null)
            {
                BookCart? existingBook = _bookCartRepository.CheckExistedInCart(bookId);
                if (existingBook == null)
                {
                    BookCart bookCart = new BookCart()
                    {
                        BookName = book.BookName,
                        AuthorName = book.Author.AuthorName,
                        BookGenreType = book.BookCategory.BookGenreType,
                        PublisherName = book.Publisher.PublisherName,
                        Quantity = 1,
                        UnitPrice = book.Price
                    };
                    _bookCartRepository.AddBookToCart(bookCart);
                    MessageBox.Show("Added successfully.");
                    LoadBookCartList();
                }
                else
                {
                    MessageBox.Show("Book is existed.");
                }
            }
        }
        private void btnDeleteFromCart_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show($"Do you want to delete book: {book.BookName}?",
                                                      "Confirm Deleting",
                                                      MessageBoxButton.YesNo,
                                                      MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
                return;
            Button button = sender as Button;
            int bookId = (int)button?.CommandParameter;
            BookCart? existingBook = _bookCartRepository.CheckExistedInCart(bookId);
            if (existingBook != null)
            {
                BookCart bookCart = new BookCart()
                {
                    BookId = existingBook.BookId
                };
                _bookCartRepository.RemoveBookToCart(bookCart);
                MessageBox.Show("Deleted successfully.");
                LoadBookCartList();
            }
            else
            {
                MessageBox.Show("Book is not existed.");
            }
        }
    }
}
