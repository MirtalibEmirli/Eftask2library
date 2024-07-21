using Eftask2.Data;
using Eftask2.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Eftask2.Pages
{
    public partial class SignInPage : Page, INotifyPropertyChanged
    {
        private LibraryDbcontext dbcontext;

        
        private Student student;
        public Student Student
        {
            get { return student; }
            set { student = value; OnPropertyChanged(); }
        }

        public SignInPage()
        {
            InitializeComponent();
            DataContext = this;
            dbcontext = new LibraryDbcontext();
            Student = new Student();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var students = dbcontext.Students.ToList();
                foreach (var item in students)
                {
                    if (item.FirstName == Student.FirstName && item.Password == Student.Password)
                    {
                        MessageBox.Show("Successfully Logged In");
                        NavigationService.Navigate(new UserPage(item.Id));
                        Student = new Student();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
