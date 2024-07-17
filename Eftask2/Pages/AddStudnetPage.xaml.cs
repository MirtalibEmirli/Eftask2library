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
    
    public partial class AddStudnetPage : Page
    {


        LibraryDbcontext dbcontext;
        public AddStudnetPage()
        {
            InitializeComponent();
            dbcontext = new LibraryDbcontext();
            DataContext = this;

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(nametext.Text)&&string.IsNullOrEmpty(lname.Text)&&string.IsNullOrEmpty(termtext.Text)))
                {
                    int term;
                    bool isParsed = int.TryParse(termtext.Text, out term);
                    if (isParsed)
                    {
                        Student student = new Student
                        {
                            FirstName = nametext.Text,
                            LastName = lname.Text,
                            Term=term
                        };
                        dbcontext.Students.Add(student);
                        dbcontext.SaveChanges();
                        MessageBox.Show("Succeed");
                    }
                }
            }
            catch (Exception ex )
            {
                MessageBox.Show("I see the errors" + ex.Message);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
