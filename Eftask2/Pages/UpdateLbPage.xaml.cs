using Eftask2.Data;
using Eftask2.Models;
using System;
using System.Collections.Generic;
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

namespace Eftask2.Pages
{
 
    public partial class UpdateLbPage : Page, INotifyPropertyChanged
    {


        LibraryDbcontext dbcontext;
        public Librarian p1 { get; set; }
        public Librarian P1
        {
            get { return p1; }
            set { p1 = value; OnPropertyChanged(); }
        }

        public Librarian orgnal { get; set; }
        public Librarian Orgnal
        {
            get { return orgnal; }
            set { orgnal = value; OnPropertyChanged(); }
        }
        public UpdateLbPage()
        {
            InitializeComponent();
            DataContext = this;

        }


        public UpdateLbPage(Librarian b)
        {
            dbcontext = new LibraryDbcontext();
            InitializeComponent();
            DataContext = this;
            P1 = new Librarian
            {
                FirstName = b.FirstName,
                Id = b.Id,
                LastName = b.LastName
            };
            Orgnal = b;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (P1.FirstName != Orgnal.FirstName || P1.LastName != Orgnal.LastName)
            {
                orgnal.LastName = P1.LastName;
                orgnal.FirstName = P1.FirstName;
                dbcontext.Librarians.Update(orgnal);
                dbcontext.SaveChanges();
                NavigationService.GoBack();

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
