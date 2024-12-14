using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp.Components
{
    internal class MTC
    {
        public MTC() { }
        static public int Get_MTC_Type(string type)
        {
            var context = new TransportDBEntities();

            // Query TipMT table to find a match based on the provided type
            var result = context.TipMTs
                                .Where(t => (type.Contains("Bus") && t.nume.Equals("Autobuz")) ||
                                           (type.Contains("Tram") && t.nume.Equals("Tramvai")) ||
                                           (type.Contains("Trolleybus") && t.nume.Equals("Troleibuz")) ||
                                           (type.Contains("Subway") && t.nume.Equals("Metrou")))
                                .Select(t => t.id_unic)
                                .FirstOrDefault();
            return result != 0 ? result : -1;
        }
    }
}
