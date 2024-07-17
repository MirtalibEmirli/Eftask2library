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
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Eftask2.Pages;


public partial class ScardPage : Page, INotifyPropertyChanged
{
    LibraryDbcontext context;
    private ObservableCollection<S_Cards> s_Cards { get; set; }
    public ObservableCollection<S_Cards> S_cards
    {
        get
        {
            return s_Cards;
        }

        set
        {
            s_Cards = value;
            OnPropertyChanged();
        }
    }

    public ScardPage()
    {
        InitializeComponent();
        DataContext = this;
        context = new LibraryDbcontext();
        S_cards = new ObservableCollection<S_Cards>(context.S_Cards.ToList());

    }

    private void Read_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            S_cards = new ObservableCollection<S_Cards>(context.S_Cards.ToList());

        }
        catch (Exception ex)
        {

            MessageBox.Show(ex.Message);
        }
    }



    private void Add_Click(object sender, RoutedEventArgs e)
    {

    }

    private void Delete_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            foreach (var item in S_cards)
            {
                if (item == sview.SelectedItem)
                {
                    var a = MessageBox.Show("Do you want to delete?", "!!!!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (a == MessageBoxResult.Yes)
                    {
                        var book = context.Books.Single(a => a.Id == item.Id_Book);
                        book.Quantity += 1;
                        context.Books.Update(book);
                        S_cards.Remove(item);
                        context.S_Cards.Remove(item);
                        context.SaveChanges();
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

    private void Back_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }
    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}




