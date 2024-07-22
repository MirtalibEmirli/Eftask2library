using Eftask2.Data;
using Eftask2.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Eftask2.Pages
{
    public partial class MybookPage : Page, INotifyPropertyChanged
    {
        private LibraryDbcontext dbcontext;
        private int ID;
        private ObservableCollection<Book> books;

        public ObservableCollection<Book> Books
        {
            get { return books; }
            set { books = value; OnPropertyChanged(); }
        }

        public MybookPage()
        {
            InitializeComponent();
            dbcontext = new LibraryDbcontext();
            Books = new ObservableCollection<Book>();
            DataContext = this;
            LoadData();
        }

        public MybookPage(int id)
        {
            InitializeComponent();
            ID = id;
            dbcontext = new LibraryDbcontext();
            Books = new ObservableCollection<Book>();
            DataContext = this;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                Books.Clear();
                var booksList = dbcontext.S_Cards
                    .Where(sc => sc.Id_Student == ID)
                    .Select(sc => sc.Book)
                    .ToList();

                foreach (var book in booksList)
                {
                    Books.Add(book);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedBook = booksview.SelectedItem as Book;
                if (selectedBook != null)
                {
                    Books.Remove(selectedBook);
                    var sCardToReturn = dbcontext.S_Cards.Single(sc => sc.Id_Student == ID && sc.Id_Book == selectedBook.Id);
                    sCardToReturn.DateIn = DateOnly.FromDateTime(DateTime.Now);
                    dbcontext.S_Cards.Update(sCardToReturn);
                    dbcontext.SaveChanges();
                }
                else
                {
                    MessageBox.Show("No book selected.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error returning book: {ex.Message}");
            }
        }
    }
}
