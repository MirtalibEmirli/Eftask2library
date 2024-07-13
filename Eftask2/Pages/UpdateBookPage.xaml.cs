using Eftask2.Data;
using Eftask2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Eftask2.Pages
{
    
    public partial class UpdateBookPage : Page,INotifyPropertyChanged
    {
        LibraryDbcontext dbcontext;
        public Book p1 { get; set; }
        public Book P1 { 
            get { return p1; }
            set { p1 = value; OnPropertyChanged(); } }
        
        public Book orgnal { get; set; }
        public Book Orgnal
        { 
            get { return orgnal; }
            set { orgnal = value; OnPropertyChanged(); } }


        public UpdateBookPage()
        {
            InitializeComponent();
            DataContext = this;
        }


        public UpdateBookPage(Book b)
        {
            dbcontext = new LibraryDbcontext();
            InitializeComponent();
            DataContext = this;
            P1 = new Book(b);
            Orgnal = b;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(P1.Name!= Orgnal.Name || P1.Pages != Orgnal.Pages
                ||P1.IdAuthor!=Orgnal.IdAuthor||
                P1.IdCategory!=P1.IdCategory||
                P1.Quantity!=Orgnal.Quantity
                ||Orgnal.YearPress!=P1.YearPress
                )
            {
                dbcontext.Books.Remove(orgnal);
                dbcontext.Books.Add(P1);
                dbcontext.SaveChanges();
            NavigationService.GoBack();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();

        }
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
