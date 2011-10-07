using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using PWMM.Models;
using PWMM.Models.ObjectMenager;
using System.Web.Security;
using System.Diagnostics;

namespace PWMM.Controllers
{
    public class ProfilController : Controller
    {
        //
        // GET: /Profil/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /UploadFile/
        public ActionResult Upload()
        {
            return View();
        }

        // POST /Upload/
        [HttpPost]
        public ActionResult Upload(UploadFileModel fileUploadModel, HttpPostedFileBase file)
        {
            ProfilMenager profilMenager = new ProfilMenager();
            if (file != null && file.ContentLength > 0) 
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data"), User.Identity.Name.ToString(), fileName);
                //var path = "";

                file.SaveAs(path);
                // Dorobić zmneijszanie zdjecia
                // Przekazanie wszystkich danych dotyczacych pliku juz po zapisaniu go na dysk ! 
                profilMenager.Add(fileUploadModel, User.Identity.Name.ToString(), path);
            }
            return View(fileUploadModel);  
        }
    }
}
