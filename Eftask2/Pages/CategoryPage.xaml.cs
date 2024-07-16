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
    /// Interaction logic for CategoryPage.xaml
    /// </summary>
    public partial class CategoryPage : Page,INotifyPropertyChanged
    {

        LibraryDbcontext dbcontext;
        private ObservableCollection<Category> categoires { get; set; }
        public ObservableCollection<Category> Categories
        {
            get { return categoires; }
            set { categoires = value; OnPropertyChanged(); }

        }
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public CategoryPage()
        {
            InitializeComponent();
            DataContext = this;
            dbcontext = new LibraryDbcontext();
            Categories = new ObservableCollection<Category>(dbcontext.Categories.ToList());
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (var item in Categories)
                {
                    if (item == categoryview.SelectedItem)
                    {
                        var a = MessageBox.Show("Do you want to delete?", "!!!!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        if (a == MessageBoxResult.Yes)
                        {
                            Categories.Remove(item);
                            dbcontext.Categories.Remove(item);
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
            NavigationService.Navigate(new AddCategoryPage());
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (categoryview.SelectedItem != null)
                {
                    Category b = new Category();
                    var c = categoryview.SelectedItem;
                    b = c as Category;
                    if (b is not null)
                    {
                        NavigationService.Navigate(new UpdateCategoryPage(b));
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
                Categories = new ObservableCollection<Category>(dbcontext.Categories.ToList());

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
    }
}
