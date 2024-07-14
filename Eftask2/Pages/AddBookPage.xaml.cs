using Eftask2.Commands;
using Eftask2.Data;
using Eftask2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Eftask2.Pages
{
    public partial class AddBookPage : Page, INotifyPropertyChanged
    {
        private LibraryDbcontext appDb;
        private List<Category> categories;
        private List<Author> authors;

        public AddBookPage()
        {
            InitializeComponent();
            appDb = new LibraryDbcontext();
            Categories = appDb.Categories.ToList();
            Authors = appDb.Authors.ToList();
            DataContext = this;

            AddBookCommand = new RelayCommand(AddBook);
            BackCommand = new RelayCommand(Back);

           
             
            Pages = 0;
            YearPress = DateTime.Now.Year;
            Quantity = 0;
            SelectedAuthor = Authors.FirstOrDefault();
            SelectedCategory = Categories.FirstOrDefault();
        }

        public string name { get; set; }
        public string Name
        {
            get { return name; }
            set
            {
                 
                    name = value;
                    OnPropertyChanged();
                
            }
        }

        private int pages;
        public int Pages
        {
            get => pages;
            set
            {
                if (pages != value)
                {
                    pages = value;
                    OnPropertyChanged();
                }
            }
        }

        private int yearPress;
        public int YearPress
        {
            get => yearPress;
            set
            {
                if (yearPress != value)
                {
                    yearPress = value;
                    OnPropertyChanged();
                }
            }
        }

        private int quantity;
        public int Quantity
        {
            get => quantity;
            set
            {
                if (quantity != value)
                {
                    quantity = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<Category> Categories
        {
            get => categories;
            set
            {
                if (categories != value)
                {
                    categories = value;
                    OnPropertyChanged();
                }
            }
        }

        private Category selectedCategory;
        public Category SelectedCategory
        {
            get => selectedCategory;
            set
            {
                if (selectedCategory != value)
                {
                    selectedCategory = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<Author> Authors
        {
            get => authors;
            set
            {
                if (authors != value)
                {
                    authors = value;
                    OnPropertyChanged();
                }
            }
        }

        private Author selectedAuthor;
        public Author SelectedAuthor
        {
            get => selectedAuthor;
            set
            {
                if (selectedAuthor != value)
                {
                    selectedAuthor = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AddBookCommand { get; set; }
        public ICommand BackCommand { get; set; }

        private void AddBook(object o)
        {
            try
            {
                Name = nametext.Text;
                 
                var author = SelectedAuthor;
                var category = SelectedCategory;

                 
                if (author == null || category == null)
                {
                    MessageBox.Show("Please select both an author and a category.");
                    return;
                }

                var book = new Book
                {
                    Name = Name,
                    Pages = Pages,
                    YearPress = YearPress,
                    Quantity = Quantity,
                    IdAuthor = author.Id,
                    IdCategory = category.Id,
                };

                appDb.Books.Add(book);
                appDb.SaveChanges();
                MessageBox.Show("Book added successfully!");
            }
            catch (Exception ex)
            {
                
                MessageBox.Show($"An error occurred: {ex.Message} ");
            }
        }

        private void Back(object o)
        {
            NavigationService.GoBack();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
