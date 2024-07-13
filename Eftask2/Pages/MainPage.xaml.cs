using Eftask2.Data;
using Eftask2.Models;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Eftask2.Pages
{
    public partial class MainPage : Page, INotifyPropertyChanged
    {
        private LibraryDbcontext _context;
        private Admin _admin;
        private string _username;
        private string _pass;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        public string Pass
        {
            get => _pass;
            set
            {
                _pass = value;
                OnPropertyChanged();
            }
        }

        public MainPage()
        {
            InitializeComponent();
            _context = new LibraryDbcontext();
            DataContext = this;
            try
            {
                _admin = _context.Admins.FirstOrDefault() ?? throw new Exception("No admin found in the database.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
                Environment.Exit(1);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            try
            {
                if (_username == _admin?.userName && _pass == _admin?.Password)
                {
                    MessageBox.Show("Login successful", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.Navigate(new FirstPage());

                }
                else
                {
                    MessageBox.Show("Login Invalid");

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
