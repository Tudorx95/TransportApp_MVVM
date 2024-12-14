using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp.Components
{
    internal class Person
    {
        static public bool ExistPerson(string firstName, string lastName, string email)
        {
            var context = new TransportDBEntities();
            // Check if the person already exists
            var pers = context.Persoanas
                      .FirstOrDefault(p => p.nume == firstName && p.prenume == lastName && p.email == email);
            if (pers != null)
                return true;
            return false;
        }
        static public bool Add_Persoana(string firstName, string lastName, string email, int tip_pers = 1)
        {
            var context = new TransportDBEntities();
            var pers= context.Persoanas.Where(p=> p.nume == firstName && p.prenume == lastName).FirstOrDefault();
            if(pers != null)
            {
                MessageBox.Show($"Person already exists!");
                return false;
            }
            var pers2 = new Persoana
            {
                nume = firstName,
                prenume = lastName,
                tip_persoana = tip_pers,
                email = email
            };
            context.Persoanas.Add(pers2);
            context.SaveChanges();
            MessageBox.Show("Person inserted succesfully!");
            return true;
        }
        static public void DeletePerson(string firstName,string lastName,  string email, int tip_pers=1)
        {
            try
            {
                var context = new TransportDBEntities();
                var person = context.Persoanas.FirstOrDefault(p => 
                    p.nume == firstName && p.prenume == lastName && p.email==email && p.tip_persoana==tip_pers);

                if (person != null)
                {
                    context.Persoanas.Remove(person);
                    context.SaveChanges();
                    MessageBox.Show($"Person '{firstName} {lastName}' has been deleted successfully.");
                    return;
                }
                else
                {
                    MessageBox.Show($"No person found with the name '{firstName} {lastName}'.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting person: {ex.Message}");
            }
        }

        static public int GetPersonID(string firstName,string lastName,string email)
        {
            var context = new TransportDBEntities();
            var personID = context.Persoanas.FirstOrDefault(p=> p.nume == firstName && p.prenume==lastName 
                    && p.email==email);
            if(personID != null)
                return personID.id_unic;
            return -1;
        }
    }


}
