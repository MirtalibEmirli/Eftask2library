using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Eftask2.Data;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Eftask2.Models;
using System.Collections.ObjectModel;
namespace Eftask2.Pages;


public partial class BookPage : Page, INotifyPropertyChanged
{


    LibraryDbcontext dbcontext;
    private ObservableCollection<Book> books { get; set; }
    public ObservableCollection<Book> Books {
        get { return books; }
        set { books = value;OnPropertyChanged(); }
        
    }


    public BookPage()
    {
        InitializeComponent();
        DataContext = this;
        dbcontext = new LibraryDbcontext();
        Books = new ObservableCollection<Book >(dbcontext.Books.ToList());

    }


    private void Back_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }



    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void Read_Click(object sender, RoutedEventArgs e)
    {

        try
        {
        Books = new ObservableCollection<Book>(dbcontext.Books.ToList());

        }
         
        catch (Exception ex)
        {

            MessageBox.Show(ex.Message);
        }

    }
    //////////////////////////

    private void Update_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (booksview.SelectedItem != null)
            {
                Book b = new Book();
                var c = booksview.SelectedItem;
                b = c as Book;
                if (b is not null)
                {
                    NavigationService.Navigate(new UpdateBookPage(b));
                }
            }
        }
        catch (Exception ex)
        {

            MessageBox.Show(ex.Message);
        }
      
    }

    private void Add_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new AddBookPage());
    }

    private void Delete_Click(object sender, RoutedEventArgs e)
    {

        try
        {
            foreach (var item in Books)
            {
                if (item == booksview.SelectedItem)
                {
                    var a = MessageBox.Show("Do you want to delete?", "!!!!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (a == MessageBoxResult.Yes)
                    {
                        Books.Remove(item);
                        dbcontext.Books.Remove(item);
                        dbcontext.SaveChanges();
                        return;
                    }

                    else
                    {
                        return;
                    }

                }

            }
        }
        catch (Exception ex)
        {

            MessageBox.Show(ex.Message);
        }
       
    }
}
