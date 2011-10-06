using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PWMM.Models.DB;

namespace PWMM.Models.ObjectMenager
{
    public class ImageMenager
    {
        private arjajobsEntities1 dre = new arjajobsEntities1();

        public void Add(UploadFile upload, HttpCookie user)
        {
            PWMM.Models.DB.Image image = new PWMM.Models.DB.Image();
            image.ID_IMAGE = 30.ToString(); // dre.Image.OrderByDescending(u => u.ID_IMAGE).Take(1).SingleOrDefault().ID_IMAGE + 1;
            image.USER_ID = 5; //(from o in dre.Profil where o.LOGIN == user.ToString() select o).First(1)
            image.IMAGE1 = upload.Image.ToString();
            image.SOURCE = upload.Source;
            image.TITLE = upload.Title;
            image.TITLE2 = upload.Title2;
            image.DATE = DateTime.Now;

            dre.AddToImage(image);
            dre.SaveChanges();
        }
    }
}