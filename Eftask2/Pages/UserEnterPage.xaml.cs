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
    /// Interaction logic for UserEnterPage.xaml
    /// </summary>
    public partial class UserEnterPage : Page
    {
        public UserEnterPage()
        {
            InitializeComponent();
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SignUpPage());
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
