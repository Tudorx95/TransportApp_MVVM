using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfApp.Components;

namespace WpfApp
{
    public partial class Register : UserControl
    {
        public Register()
        {
            InitializeComponent();
        }

        //private void RegisterButton_Click(object sender, RoutedEventArgs e)
        //{
        //    // Add logic to save the user data here
        //    string firstName = FirstNameTextBox.Text;
        //    string lastName = LastNameTextBox.Text;
        //    string username = UsernameBox.Text;
        //    string email = EmailTextBox.Text;
        //    string password = Password.Text;
        //    string confirmPassword = Password2.Text;

        //    if (password != confirmPassword)
        //    {
        //        MessageBox.Show("Incorrect password!");
        //        return;
        //    }
        //    if (!IsUsernameUnique(username))
        //    {
        //        MessageBox.Show("Username already exists! Please choose another one.");
        //        return;
        //    }
        //    // here add the user in Persoane and verify its integrity
        //    if (!Person.Add_Persoana(firstName, lastName, email))
        //        return;
        //    // here just add the user in User by the generated ID from Persoana
        //    int id_pers = Person.GetPersonID(firstName, lastName, email);

        //    if (id_pers != -1 && ServiceUser.AddUser(username, password, id_pers) == true)
        //    {
        //        MessageBox.Show("Registration successfully!");
        //        SwitchToLogin();
        //        return;
        //    }
        //    // reached when the Person id is not found. An approximately impossible situation
        //    Person.DeletePerson(firstName, lastName, email);
        //    MessageBox.Show("Registration failed due to some reasons!");
        //}

        //public bool IsUsernameUnique(string username)
        //{
        //    var context = new DataClasses1DataContext();
        //    var user = context.Users.FirstOrDefault(p => p.username == username);
        //    if (user != null)
        //        return false;
        //    return true;
        //}

        //private void BackToLoginButton_Click(object sender, RoutedEventArgs e)
        //{
        //    SwitchToLogin();
        //}

        //private void SwitchToLogin()
        //{
        //    NavigationBar.NavigateTo(typeof(Login));
        //}
    }
}