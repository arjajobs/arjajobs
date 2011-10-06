using System.Linq;
using PWMM.Models.DB;
using PWMM.Models;
using System;

namespace MVCDemo.Models.ObjectManager
{
    public class UserManager
    {
        private arjajobsEntities1 dre = new arjajobsEntities1();

        public void Add(RegisterModel user)
        {
            PWMM.Models.DB.Profil profil = new PWMM.Models.DB.Profil();
            profil.ID_USER = dre.Profil.OrderByDescending(u => u.ID_USER).Take(1).SingleOrDefault().ID_USER + 1;
            profil.LOGIN = user.UserName;
            profil.EMAIL = user.Email;
            profil.PASS = user.Password;
            profil.RULES = 1;

            dre.AddToProfil(profil);
            dre.SaveChanges();
        }

        /** Przy zakładaniu nowego konta sprawdzanie czy dany login istnieje już w bazie */
        public bool IsLoginExist(string userLogIn)
        {
            return (from o in dre.Profil where o.LOGIN == userLogIn select o).Any();
        }

        /** Logownie do konta - sprawdzenie loginu i hasła { dodać potem szyfrowanie }*/
        public bool LogOnLoginAndPassExist(string login, string pass)
        {
            return (from o in dre.Profil where (o.LOGIN == login) && (o.PASS == pass) select o).Any();
        }
    }
}
