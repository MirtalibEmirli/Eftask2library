using Eftask2.Data;
using Eftask2.Models;
using System;
using System.Collections.Generic;
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

namespace Eftask2.Pages
{
     
    public partial class UpdateCategoryPage : Page
    {


        LibraryDbcontext dbcontext;
        Category category;
        public UpdateCategoryPage()
        {
            InitializeComponent();
            dbcontext = new LibraryDbcontext();
        }
        public UpdateCategoryPage(Category c)
        {
            InitializeComponent();
            dbcontext = new LibraryDbcontext();
            category = c;

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(nametext.Text))
                {
                    category.Name = nametext.Text;
                    dbcontext.Categories.Update(category);
                    dbcontext.SaveChanges();
                    MessageBox.Show($"{category.Name} updated");
                }
                else
                {
                    MessageBox.Show($"Please enter valid Name");

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();

        }
    }
}
