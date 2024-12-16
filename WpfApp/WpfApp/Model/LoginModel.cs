using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp.Components;

namespace WpfApp.Model
{
    public class LoginModel
    {
        public static bool Connected { get; set; } = false;
        public static bool VerifyUser(string username, string password)
        {
            return ServiceUser.Exist_User(username, password);
        }
    }
}
