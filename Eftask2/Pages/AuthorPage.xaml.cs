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
using static System.Reflection.Metadata.BlobBuilder;

namespace Eftask2.Pages
{
    /// <summary>
    /// Interaction logic for AuthorPage.xaml
    /// </summary>
    public partial class AuthorPage : Page,INotifyPropertyChanged
    {

        LibraryDbcontext dbcontext;

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<Author> authors { get; set; }
        public ObservableCollection<Author> Authors
        {
            get { return authors; }
            set { authors = value; OnPropertyChanged(); }

        }
        /// <Costructor>
        public AuthorPage()
        {
            InitializeComponent();
            DataContext = this;
            dbcontext = new LibraryDbcontext();
           Authors = new ObservableCollection<Author>(dbcontext.Authors.ToList());
           

        }
 


        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (var item in Authors)
                {
                    if (item == authorsview.SelectedItem)
                    {
                        var a = MessageBox.Show("Do you want to delete?", "!!!!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        if (a == MessageBoxResult.Yes)
                        {
                            Authors.Remove(item);
                            dbcontext.Authors.Remove(item);
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

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddAuthorPage());
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (authorsview.SelectedItem != null)
                {
                    Author b = new Author();
                    var c = authorsview.SelectedItem;
                    b = c as Author;
                    if (b is not null)
                    {
                        NavigationService.Navigate(new UpdateAuthorPage(b)); 
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Read_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Authors = new ObservableCollection<Author>(dbcontext.Authors.ToList());

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
