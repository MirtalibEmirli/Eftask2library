using Eftask2.Data;
using Eftask2.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Eftask2.Pages
{
    public partial class UpdateStudentPage : Page, INotifyPropertyChanged
    {
        private LibraryDbcontext _dbContext;
        private Student _currentStudent;
        private Student _originalStudent;

        public UpdateStudentPage()
        {
            InitializeComponent();
            DataContext = this;
            _dbContext = new LibraryDbcontext();
        }

        public UpdateStudentPage(Student student) : this()
        {
            CurrentStudent = new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Term = student.Term
            };
            OriginalStudent = student;
        }

        public Student CurrentStudent
        {
            get => _currentStudent;
            set
            {
                _currentStudent = value;
                OnPropertyChanged();
            }
        }

        public Student OriginalStudent
        {
            get => _originalStudent;
            set
            {
                _originalStudent = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CurrentStudent.FirstName != OriginalStudent.FirstName ||
                    CurrentStudent.LastName != OriginalStudent.LastName ||
                    CurrentStudent.Term != OriginalStudent.Term)
                {
                    OriginalStudent.FirstName = CurrentStudent.FirstName;
                    OriginalStudent.LastName = CurrentStudent.LastName;
                    OriginalStudent.Term = CurrentStudent.Term;

                    _dbContext.Students.Update(OriginalStudent);
                    _dbContext.SaveChanges();
                    NavigationService.GoBack();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
