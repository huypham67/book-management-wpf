using BusinessObjects.Models;
using Repositories.AuthorRepositories;
using Repositories.BookCategoryRepositories;
using Repositories.BookRepositories;
using Repositories.PublisherRepositories;
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
    /// Interaction logic for BookDetailWindowNew.xaml
    /// </summary>
    public partial class BookDetailWindow : Window
    {
        private IBookRepository _bookRepository = new BookRepository();
        private IAuthorRepository _authorRepository = new AuthorRepository();
        private IBookCategoryRepository _bookCategoryRepository = new BookCategoryRepository();
        private IPublisherRepository _publisherRepository = new PublisherRepository();
        private Book _selected = null;
        private MainAdminWindow _mainAdminWindow;
        public BookDetailWindow(Book book)
        {
            InitializeComponent();
            if (book != null)
            {
                txtBlockHeader.Text = "UPDATE A BOOK";
                this.DataContext = book;
                _selected = book;
            }
        }
        private void BookDetailWindow_Load(object sender, EventArgs e)
        {
            LoadBookAuthor();
            LoadBookCategory();
            LoadBookPublisher();
        }
        private void LoadBookAuthor()
        {
            cboBoxBookAuthor.ItemsSource = null;
            cboBoxBookAuthor.ItemsSource = _authorRepository.GetBookAuthors().ToList();
        }
        private void LoadBookCategory()
        {
            cboBoxBookCategory.ItemsSource = null;
            cboBoxBookCategory.ItemsSource = _bookCategoryRepository.GetBookCategories().ToList();
        }
        private void LoadBookPublisher()
        {
            cboBoxPublisher.ItemsSource = null;
            cboBoxPublisher.ItemsSource = _publisherRepository.GetBookPublishers().ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_selected == null)
            {
                Book book = new Book()
                {
                    BookName = txtBookName.Text,
                    BookDescription = txtBookDescription.Text,
                    PublicationDate = dpPublicationDate.SelectedDate ?? DateTime.Now,
                    Price = decimal.Parse(txtPrice.Text.ToString()),
                    Quantity = Int32.Parse(txtQuantity.Text.ToString()),
                    AuthorId = Int32.Parse(cboBoxBookAuthor.SelectedValue.ToString()),
                    PublisherId = Int32.Parse(cboBoxPublisher.SelectedValue.ToString()),
                    BookCategoryId = Int32.Parse(cboBoxBookCategory.SelectedValue.ToString())
                };
                _bookRepository.AddBook(book);
            }
            else
            {
                try
                {
                    Book book = new Book()
                    {
                        BookId = _selected.BookId,
                        BookName = txtBookName.Text,
                        BookDescription = txtBookDescription.Text,
                        PublicationDate = dpPublicationDate.SelectedDate ?? DateTime.Now,
                        Price = decimal.Parse(txtPrice.Text.ToString()),
                        Quantity = Int32.Parse(txtQuantity.Text.ToString()),
                        AuthorId = Int32.Parse(cboBoxBookAuthor.SelectedValue.ToString()),
                        PublisherId = Int32.Parse(cboBoxPublisher.SelectedValue.ToString()),
                        BookCategoryId = Int32.Parse(cboBoxBookCategory.SelectedValue.ToString())
                    };
                    _bookRepository.UpdateBook(book);
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
        private void CheckValidationBookDetail()
        {
            if (string.IsNullOrWhiteSpace(txtBookDescription.Text))
            {
                throw new InvalidOperationException("Book description cannot be empty.");
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                throw new InvalidOperationException("Invalid price value.");
            }

            if (!int.TryParse(txtQuantity.Text, out int quantity))
            {
                throw new InvalidOperationException("Invalid quantity value.");
            }

            if (cboBoxBookAuthor.SelectedValue == null ||
                !int.TryParse(cboBoxBookAuthor.SelectedValue.ToString(), out int authorId))
            {
                throw new InvalidOperationException("Invalid author selected.");
            }

            if (cboBoxPublisher.SelectedValue == null ||
                !int.TryParse(cboBoxPublisher.SelectedValue.ToString(), out int publisherId))
            {
                throw new InvalidOperationException("Invalid publisher selected.");
            }

            if (cboBoxBookCategory.SelectedValue == null ||
                !int.TryParse(cboBoxBookCategory.SelectedValue.ToString(), out int bookCategoryId))
            {
                throw new InvalidOperationException("Invalid book category selected.");
            }
        }
    }
}
