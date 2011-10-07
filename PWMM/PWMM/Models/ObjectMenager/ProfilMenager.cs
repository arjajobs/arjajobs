using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PWMM.Models.DB;

namespace PWMM.Models.ObjectMenager
{
    public class ProfilMenager
    {
        private arjajobsEntities4 dre = new arjajobsEntities4();

        public void Add(UploadFileModel model, string user, string path)
        {
            PWMM.Models.DB.Image image = new PWMM.Models.DB.Image();
            image.ID_IMAGE = 35; // dre.Image.OrderByDescending(u => u.ID_IMAGE).Take(1).SingleOrDefault().ID_IMAGE + 1;
            image.ID_USER = 20; //(from o in dre.Profil where o.LOGIN == user.ToString() select o).First(1)
            image.IMAGE1 = path.ToString();
            image.SOURCE = model.Source;
            image.TITLE = model.Title;
            image.TITLE2 = model.Title2;
            image.DATE = DateTime.Now;

            dre.AddToImage(image);
            dre.SaveChanges();
        }
    }
}