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

namespace Eftask2.Pages;

public partial class UserPage : Page
{
    public UserPage()
    {
        InitializeComponent();
    }
    int Id;
    public UserPage(int id)
    {
        InitializeComponent();
        DataContext = this;
       Id = id;

    }

     

   

    private void Getbookbutton_Click(object sender, RoutedEventArgs e)
    {
         try
        {
            NavigationService.Navigate(new GetBookPage(Id));
        }
        catch (Exception)
        {

            throw;
        }

    }

    private void ReturnButton_Click(object sender, RoutedEventArgs e)
    {  

    }

    private void Mybookbutton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            NavigationService.Navigate(new MybookPage(Id));

        }
        catch (Exception)
        {

            throw;
        }
    }

    private void Back_Click_1(object sender, RoutedEventArgs e)
    {
        NavigationService.GoBack();
    }

    private void allbookbutton_Click_1(object sender, RoutedEventArgs e)
    { 
        try
        {
            NavigationService.Navigate(new AllBookPage());

        }
        catch (Exception)
        {

            throw;
        }
    }
}
