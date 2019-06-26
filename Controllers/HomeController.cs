using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using barCode.Models;

namespace barCode.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GenerateQR(info INFO)
         {

          QRCodeGenerator qrGenerator = new QRCodeGenerator();
          QRCodeData qrCodeData = qrGenerator.CreateQrCode("Name: "+INFO.Name+" Phone No: "+INFO.Phone+" Email: "+""+INFO.Email, QRCodeGenerator.ECCLevel.Q);
          QRCode qrCode = new QRCode(qrCodeData);
          Bitmap qrCodeImage = qrCode.GetGraphic(20);
            string path1 = Guid.NewGuid() + "qrcode.png";
            string path = Server.MapPath("~/Images/"+path1);
            try
            {
                qrCodeImage.Save(path);
            }
            catch (Exception e)
            {

            }

           string ImgUrl = "Images/" + path1;

            ViewBag.imgS = ImgUrl;

           return Json(new { img = ImgUrl }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}