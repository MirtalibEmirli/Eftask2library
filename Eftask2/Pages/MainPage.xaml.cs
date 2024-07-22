using Eftask2.Data;
using Eftask2.Models;
using System;
using System.Collections.ObjectModel;
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
        private ObservableCollection< Admin> admins;
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
            try
            {

                InitializeComponent();
            _context = new LibraryDbcontext();
            admins = new ObservableCollection<Admin>(_context.Admins.ToList());
            DataContext = this;
                 
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
            NavigationService.GoBack();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            try
            {
                bool isfound = false;
                foreach (var item in admins)
                {
                    if (_username == item.userName && _pass == item?.Password)
                    {
                        MessageBox.Show("Login successful", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        NavigationService.Navigate(new FirstPage());
                        isfound = true;
                        return;
                    }
 
                }
                if (!isfound)
                {
                    MessageBox.Show("Admin not found");
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
