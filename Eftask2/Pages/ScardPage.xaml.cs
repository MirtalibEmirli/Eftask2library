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
    public partial class ScardPage : Page, INotifyPropertyChanged
    {
        private LibraryDbcontext context;
        private ObservableCollection<S_Cards> s_Cards;

        public ObservableCollection<S_Cards> S_cards
        {
            get { return s_Cards; }
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

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = sview.SelectedItem as S_Cards;
                if (selectedItem != null)
                {
                    var result = MessageBox.Show("Do you want to delete?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        var book = context.Books.SingleOrDefault(b => b.Id == selectedItem.Id_Book);
                        if (book != null)
                        {
                            book.Quantity += 1;
                            context.Books.Update(book);
                        }
                        S_cards.Remove(selectedItem);
                        context.S_Cards.Remove(selectedItem);
                        context.SaveChanges();
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
