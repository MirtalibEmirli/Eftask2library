using Eftask2.Data;
using Eftask2.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Eftask2.Pages
{
    public partial class GetBookPage : Page, INotifyPropertyChanged
    {
        private readonly LibraryDbcontext dbcontext;
        int Id;

        private ObservableCollection<Librarian> librarians;
        public ObservableCollection<Librarian> Librarians1
        {
            get { return librarians; }
            set { librarians = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Book> books;
        public ObservableCollection<Book> Books
        {
            get { return books; }
            set { books = value; OnPropertyChanged(); }
        }

        public GetBookPage()
        {
            InitializeComponent();
            DataContext = this;
            dbcontext = new LibraryDbcontext();
            LoadData();
        }

        public GetBookPage(int s)
        {
            InitializeComponent();
            DataContext = this;
            dbcontext = new LibraryDbcontext();
            Id = s;
            LoadData();
        }

        private void LoadData()
        {
            Librarians1 = new ObservableCollection<Librarian>(dbcontext.Librarians.ToList());
            Books = new ObservableCollection<Book>(dbcontext.Books.ToList());
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Get_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var book = booksview.SelectedItem as Book;
                if (book == null)
                {
                    MessageBox.Show("Please select a book.");
                    return;
                }

                var lib = Librarians.SelectedItem as Librarian;
                if (lib == null)
                {
                    MessageBox.Show("Please select a librarian.");
                    return;
                }

                var existingStudent = dbcontext.Students.FirstOrDefault(st => st.Id == Id);
                if (existingStudent == null)
                {
                    MessageBox.Show("The selected student does not exist.");
                    return;
                }

                book.Quantity -= 1;
                S_Cards cards = new S_Cards
                {
                    Id_Student = existingStudent.Id,
                    Id_Book = book.Id,
                    DateOut = DateOnly.FromDateTime(DateTime.Now),
                    Id_Lib = lib.Id
                };

                dbcontext.Books.Update(book);
                dbcontext.S_Cards.Add(cards);
                dbcontext.SaveChanges();
                MessageBox.Show("Please dont lost Book");
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
