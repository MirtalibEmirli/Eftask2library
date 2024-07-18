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

namespace Eftask2.Pages
{
    /// <summary>
    /// Interaction logic for LibrarianPage.xaml
    /// </summary>
    public partial class LibrarianPage : Page
    {
        LibraryDbcontext dbcontext;
        private ObservableCollection<Librarian> librarians { get; set; }
        public ObservableCollection<Librarian> Librarians
        {
            get { return librarians; }
            set { librarians = value; OnPropertyChanged(); }
        }


        public LibrarianPage()
        {
            InitializeComponent();
            dbcontext = new LibraryDbcontext();
            DataContext = this;
            Librarians = new ObservableCollection<Librarian>(dbcontext.Librarians.ToList());
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Back_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Delete_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            try
            {
                foreach (var item in Librarians)
                {
                    if (item == lbsview.SelectedItem)
                    {
                        var a = System.Windows.MessageBox.Show("Do you want to delete?", "!!!!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        if (a == MessageBoxResult.Yes)
                        {
                            Librarians.Remove(item);
                            dbcontext.Librarians.Remove(item);
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

                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void Add_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddLibrarianPage());
        }

        private void Update_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                if (lbsview.SelectedItem != null)
                {
                    Librarian b = new Librarian();
                    var c = lbsview.SelectedItem;
                    b = c as Librarian;
                    if (b is not null)
                    {
                        NavigationService.Navigate(new UpdateLbPage(b));
                    }
                }
            }
            catch (Exception ex)
            {

                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void Read_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                Librarians = new ObservableCollection<Librarian>(dbcontext.Librarians.ToList());

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }
    }
}
