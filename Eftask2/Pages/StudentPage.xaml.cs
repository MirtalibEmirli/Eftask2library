using Eftask2.Data;
using Eftask2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Eftask2.Pages;


public partial class StudentPage : Page, INotifyPropertyChanged
{

    LibraryDbcontext dbcontext;

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private ObservableCollection<Student> students { get; set; }
    public ObservableCollection<Student> Students
    {
        get { return students; }
        set { students = value; OnPropertyChanged(); }

    }
    public StudentPage()
    {
        InitializeComponent();
        DataContext = this;
        dbcontext = new LibraryDbcontext();
        Students = new ObservableCollection<Student>(dbcontext.Students.ToList());
    }

    private void Read_Click(object sender, RoutedEventArgs e)
    {
        Students = new ObservableCollection<Student>(dbcontext.Students.ToList());
    }

    private void Update_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            try
            {
                if (sview.SelectedItem != null)
                {
                    Student b = new Student();
                    var c = sview.SelectedItem;
                    b = c as Student;
                    if (b is not null)
                    {
                        NavigationService.Navigate(new UpdateStudentPage(b));
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        catch (Exception ex)
        {

            MessageBox.Show(ex.Message);
        }
    }

    private void Add_Click(object sender, RoutedEventArgs e)
    {

    }

    private void Delete_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            foreach (var item in Students)
            {
                if (item ==  sview.SelectedItem)
                {
                    var a = MessageBox.Show("Do you want to delete?", "!!!!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (a == MessageBoxResult.Yes)
                    {
                        Students.Remove(item);
                        dbcontext.Students.Remove(item);
                        dbcontext.SaveChanges();
                        return;
                    }

                    else
                    {
                        return;
                    }

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
}
