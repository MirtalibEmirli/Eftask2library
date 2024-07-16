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
     
    public partial class AddCategoryPage : Page
    {
        public AddCategoryPage()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(nametext.Text))
                {
                    var context = new LibraryDbcontext();
                    var category = new Category
                    {
                        Name = nametext.Text
                    };
                    context.Categories.Add(category);
                    context.SaveChanges();
                    MessageBox.Show($"{nametext.Text} added");
                }
                else
                {
                    MessageBox.Show($"Invalid name");

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
