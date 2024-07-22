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




        public SignUpPage()
        {
            dbcontext = new LibraryDbcontext();
            InitializeComponent();
            Student = new Student();
            msg = random.Next(200, 999);

        }

           

          public bool IsRegisterCommand( )
          {
              return Student != null &&
                     !string.IsNullOrWhiteSpace(Student.FirstName) &&
                     !string.IsNullOrWhiteSpace(Student.Mail) &&
                     Codemail == msg &&
                     !string.IsNullOrWhiteSpace(Student.Password);
          } 



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IsRegisterCommand())
                {
                    _ = int.TryParse(Term.Text, out int t);
                    if (Student != null)
                    {
                        Student = new Student
                        {
                            FirstName = name.Text,
                            LastName = Lastname.Text,
                            Term = t,
                            Mail = Mail.Text,
                            Password = pass.Text

                        };
                        dbcontext.Students.Add(Student);
                        dbcontext.SaveChanges();
                        Student = new Student();


                        NavigationService.GoBack();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private static readonly Regex EmailRegex = new Regex(@"^[^\s@]+@[^\s@]+\.[^\s@]+$", RegexOptions.Compiled);

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Mail.Text )&& EmailRegex.IsMatch(Mail.Text)) ;
                {
                   
                    string senderEmail = "mirtalibemirli498@gmail.com";
                    string senderPassword = "aytndmgzqcukvmds";
                    string recipientEmail = Mail.Text;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
