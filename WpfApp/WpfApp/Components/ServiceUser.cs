using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp.Components
{
    class ServiceUser
    {
        static protected Dictionary<string, string> login_details = new Dictionary<string, string> { { "", "" } };

        static public Dictionary<string, string> LoginDetails
        {
            get { return login_details; }
            set { login_details = value; }
        }
        static public int getUserID()
        {
            var context = new TransportDBEntities();
            string username = login_details.Keys.FirstOrDefault();
            string password = login_details.Values.FirstOrDefault();

            var user = context.Users.FirstOrDefault(p => p.username==username && p.password==password);
            if (user == null)
                return -1;
            return user.id_unic;
        }
        static public bool AddUser(string username, string password, int id_pers)
        {
            var context = new TransportDBEntities();
            var user = new User
            {
                username=username,
                password=password,
                id_persoana=id_pers
            };
            try
            {
                context.Users.Add(user);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message.ToString()}");
                return false;
            }
        }
        static public bool Exist_User(string username, string password)
        {
            var context =new TransportDBEntities();
            var user_username = context.Users.FirstOrDefault(p => p.username==username);
            var user_passwd = context.Users.FirstOrDefault(p => p.password==password);
            var user = context.Users.FirstOrDefault(p => p.username==username && p.password==password);
            if(user!=null)
                return true;
            if(user_username == null)
                MessageBox.Show("Incorrect Username!");
            else if(user_passwd==null)
                MessageBox.Show("Incorrect Password!");
            return false;
        }
        static public bool IsUsernameUnique(string username)
        {
            var context = new TransportDBEntities();
            var user = context.Users.FirstOrDefault(p => p.username == username);
            if (user != null)
                return false;
            return true;
        }
        public static bool RegisterUser(string firstName, string lastName, string email, string username, string password)
        {
            if (!Person.Add_Persoana(firstName, lastName, email))
                return false;
            
            int id_pers = Person.GetPersonID(firstName, lastName, email);

            if (id_pers != -1 && ServiceUser.AddUser(username, password, id_pers) == true)
            {
                MessageBox.Show("Registration successfully!");
                NavigationHelper.NavigateTo(typeof(Login));
                return true;
            }
            Person.DeletePerson(firstName, lastName, email);
            MessageBox.Show("Registration failed due to some reasons!");
            return false;
        }
    }
}
