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
            if(user_passwd!=null && user_username == null)
                MessageBox.Show("Incorrect Username!");
            else if(user_username!=null && user_passwd==null)
                MessageBox.Show("Incorrect Password!");
            return false;
        }
    }
}
