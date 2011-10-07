using System.Linq;
using PWMM.Models.DB;
using PWMM.Models;
using System;

namespace MVCDemo.Models.ObjectManager
{
    public class UserManager
    {
        private arjajobsEntities4 dre = new arjajobsEntities4();

        public void Add(RegisterModel user1)
        {
            PWMM.Models.DB.Users user = new PWMM.Models.DB.Users();
            user.ID_USER = dre.Users.OrderByDescending(u => u.ID_USER).Take(1).SingleOrDefault().ID_USER + 1;
            user.LOGIN = user1.UserName;
            user.EMAIL = user1.Email;
            user.PASS = user1.Password;
            user.RULES = 1;

            dre.AddToUsers(user);
            dre.SaveChanges();
        }

        /** Przy zakładaniu nowego konta sprawdzanie czy dany login istnieje już w bazie */
        public bool IsLoginExist(string userLogIn)
        {
            return (from o in dre.Users where o.LOGIN == userLogIn select o).Any();
        }

        /** Logownie do konta - sprawdzenie loginu i hasła { dodać potem szyfrowanie }*/
        public bool LogOnLoginAndPassExist(string login, string pass)
        {
            return (from o in dre.Users where (o.LOGIN == login) && (o.PASS == pass) select o).Any();
        }
    }
}
