using BusinessObjects.Models;
using Repositories.BookCategoryRepositories;
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
    /// Interaction logic for BookCategoryDetailWindow.xaml
    /// </summary>
    public partial class BookCategoryDetailWindow : Window
    {
        private IBookCategoryRepository _bookCategoryRepository = new BookCategoryRepository();
        private BookCategory _selected = null;
        public BookCategoryDetailWindow(BookCategory bookCategory)
        {
            InitializeComponent();
            if (bookCategory != null)
            {
                txtBlockHeader.Text = "UPDATE A BOOK CATEGORY";
                this.DataContext = bookCategory;
                _selected = bookCategory;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_selected == null)
            {
                BookCategory bookCategory = new BookCategory()
                {
                    BookGenreType = txtBookCategoryName.Text,
                    Description = txtBookCategoryDescription.Text
                };
                _bookCategoryRepository.AddBookCategory(bookCategory);
            }
            else
            {
                try
                {
                    BookCategory bookCategory = new BookCategory()
                    {
                        BookCategoryId = _selected.BookCategoryId,
                        BookGenreType = txtBookCategoryName.Text,
                        Description = txtBookCategoryDescription.Text
                    };
                    _bookCategoryRepository.UpdateBookCategory(bookCategory);
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
