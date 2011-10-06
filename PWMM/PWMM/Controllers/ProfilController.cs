using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using PWMM.Models;
using PWMM.Models.ObjectMenager;
using System.Web.Security;

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
        public ActionResult UploadFile()
        {
            return View();
        }

        // POST /Upload/
        [HttpPost]
        public ActionResult Upload(UploadFile FileUpload, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0) 
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data"), fileName);
                FileUpload.Image = path.ToString();
                file.SaveAs(path);

                ImageMenager image = new ImageMenager();
                image.Add(FileUpload, FormsAuthentication.GetAuthCookie("UserName", false));
            }
        return RedirectToAction("Index");      
        }
    }
}
