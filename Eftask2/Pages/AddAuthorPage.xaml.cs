using Eftask2.Data;
using Eftask2.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Eftask2.Pages
{
    public partial class AddAuthorPage : Page
    { 
        private LibraryDbcontext _appDb;

        

        public AddAuthorPage()
        {
            DataContext = this;
            InitializeComponent();
            _appDb = new LibraryDbcontext();
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

                Author author = new Author
                {
                    Name = nametext.Text,
                    LastName = lname.Text
                };

                _appDb.Authors.Add(author);
                _appDb.SaveChanges();
                MessageBox.Show($"{nametext.Text} added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
