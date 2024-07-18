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
    /// <summary>
    /// Interaction logic for FirstPage.xaml
    /// </summary>
    public partial class FirstPage : Page
    {
        public FirstPage()
        {
            InitializeComponent();
        }

        private void bookbutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            NavigationService.Navigate(new BookPage());
            }
            catch (Exception ex) 
            {

            MessageBox.Show(ex.Message);

            }
        }

        private void Authorbutton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                NavigationService.Navigate(new AuthorPage());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void CategoryButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CategoryPage());
        }

        private void Libbutton_Click(object sender, RoutedEventArgs e)
        {
             NavigationService.Navigate(new LibrarianPage());
        }

        private void StudentButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            NavigationService.Navigate(new StudentPage());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Scardbutton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                NavigationService.Navigate(new ScardPage());

            }
           catch(Exception ex)
            {
                MessageBox.Show(ex.Message+ex.InnerException);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
