using Eftask2.Data;
using Eftask2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
 

namespace Eftask2.Pages
{
     
    public partial class AllBookPage : Page,INotifyPropertyChanged
    {

        LibraryDbcontext dbcontext;
        private ObservableCollection<Book> books { get; set; }
        public ObservableCollection<Book> Books
        {
            get { return books; }
            set { books = value; OnPropertyChanged(); }

        }

        public AllBookPage() 
        { 
            InitializeComponent();
            DataContext = this;
            dbcontext = new LibraryDbcontext();
            Books = new ObservableCollection<Book>(dbcontext.Books.ToList());
        } 



        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
