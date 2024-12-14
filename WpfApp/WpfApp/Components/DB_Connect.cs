using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows;

namespace WpfApp.Components
{
    internal class DB_Connect
    {
        static public SqlConnection connect { get; private set; }
        public DB_Connect(string ip,string db_name)
        {
            connect = connect_to_DB(ip, db_name);
        }

        static public void connection(string ip,string db_name)
        {
            connect = connect_to_DB(ip, db_name);
        }   
        static private SqlConnection connect_to_DB(string ip, string db_name)
        {
            var connection = new SqlConnection();
            connection.ConnectionString =
            $"Server={ip};Database={db_name};Trusted_Connection=true";
            connection.Open();
            return connection;
        }

        static public bool IsDBConnected()
        {
            if(connect == null) return false;
            return true;
        }


        static public void DB_Deconnect()
        {
            connect.Close();
        }
    }
}
