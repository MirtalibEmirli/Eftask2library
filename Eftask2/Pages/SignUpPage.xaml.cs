using System;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using Eftask2.Commands;
using Eftask2.Data;
using Eftask2.Models;

namespace Eftask2.Pages
{
    public partial class SignUpPage : Page, INotifyPropertyChanged
    {
        private LibraryDbcontext dbcontext;
        private Student student;
        private int? msg;
        private int? codemail;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        Random random = new Random();
        public Student Student
        {
            get { return student; }
            set { student = value; OnPropertyChanged(); }
        }

        public int? Codemail
        {
            get { return codemail; }
            set { codemail = value; OnPropertyChanged(); }
        }

        public ICommand RegisterCommand { get; }
        public ICommand GetCode { get; set; }
        public ICommand BackCommand { get; set; }

        private static readonly Regex EmailRegex = new Regex(@"^[^\s@]+@[^\s@]+\.[^\s@]+$", RegexOptions.Compiled);

        public SignUpPage()
        {
            dbcontext = new LibraryDbcontext();
            InitializeComponent();
            Student = new Student();
            msg = random.Next(200, 999);  
            RegisterCommand = new RelayCommand(RegisterCommandExecute, IsRegisterCommand);
            GetCode = new RelayCommand(mailing, IsGetCodeCommand);
        }

        public bool IsGetCodeCommand(object obj)
        {
            return !string.IsNullOrWhiteSpace(Student?.Mail) && EmailRegex.IsMatch(Student.Mail);
        }

        public bool IsRegisterCommand(object? obj)
        {
            return Student != null &&
                   !string.IsNullOrWhiteSpace(Student.FirstName) &&
                   !string.IsNullOrWhiteSpace(Student.Mail) &&
                   Codemail == msg &&
                   !string.IsNullOrWhiteSpace(Student.Password);
        }

        public void RegisterCommandExecute(object obj)
        {
            try
            {
                if (Student != null)
                {
                    dbcontext.Students.Add(Student);
                    dbcontext.SaveChanges();
                    Student = new Student();
                    if (obj is Page page)
                    {
                        page.NavigationService.GoBack();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mailing(object? obj)
        {
            try
            {
                MessageBox.Show(msg.ToString());
                string senderEmail = "mirtalibemirli498@gmail.com";
                string senderPassword = "aytndmgzqcukvmds";
                string recipientEmail = Student.Mail;
                string smtpServer = "smtp.gmail.com";
                int smtpPort = 587;

                using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);

                    using (MailMessage mailMessage = new MailMessage(senderEmail, recipientEmail))
                    {
                        mailMessage.Subject = "Verification Code";
                        mailMessage.Body = $"Your Code is {msg}";
                        smtpClient.Send(mailMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
