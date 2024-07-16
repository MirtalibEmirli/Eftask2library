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
   
    public partial class AddLibrarianPage : Page
    {
        private LibraryDbcontext _appDb;
        public AddLibrarianPage()
        {
            DataContext = this;
            InitializeComponent();
            _appDb = new LibraryDbcontext();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nametext.Text) || string.IsNullOrWhiteSpace(lname.Text))
                {
                    MessageBox.Show("Name and Last Name cannot be empty.");
                    return;
                }

                Librarian lb = new Librarian
                {
                    FirstName = nametext.Text,
                    LastName = lname.Text
                };

                _appDb.Librarians.Add(lb);
                _appDb.SaveChanges();
                MessageBox.Show($"{nametext.Text} added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
