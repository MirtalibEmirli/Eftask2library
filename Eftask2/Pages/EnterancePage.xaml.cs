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
     
    public partial class EnterancePage : Page
    {
        public EnterancePage()
        {
            InitializeComponent();
        }

        private void admin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPage());
        }

        private void user_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserEnterPage());

        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);

        }
    }
}
