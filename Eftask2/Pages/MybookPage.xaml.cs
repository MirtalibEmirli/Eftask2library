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
        int ID;
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
            DataContext = this;
            dbcontext = new LibraryDbcontext();
            Books = new ObservableCollection<Book>();
            LoadData();
        }

        void LoadData()
        {
            try
            {
            
                Books = new ObservableCollection<Book>();
 
                var books = dbcontext.S_Cards
                    .Where(sc => sc.Id_Student == ID)
                    .Select(sc => sc.Book)
                    .ToList();

          
                foreach (var book in books)
                {
                    Books.Add(book);
                }

              
                OnPropertyChanged(nameof(Books));
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

        private void Back_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var book = booksview.SelectedItem as Book;
                Books.Remove(book);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
             }
        }
    }
}
