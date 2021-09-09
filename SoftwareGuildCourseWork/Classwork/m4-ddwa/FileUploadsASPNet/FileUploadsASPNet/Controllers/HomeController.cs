using FileUploadsASPNet.Models;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace FileUploadsASPNet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new FileUploadViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(FileUploadViewModel model)
        {
            // was a file uploaded? Did it have content?
            if (model.UploadedFile != null && model.UploadedFile.ContentLength > 0)
            {
                // turn the web path ~/Uploads into a directory (c:\foo\)
                string path = Path.Combine(Server.MapPath("~/Uploads"),
                    Path.GetFileName(model.UploadedFile.FileName));

                model.UploadedFile.SaveAs(path);
            }

            return RedirectToAction("Index");
        }

        // example of how to get the binary representation of a file for database uploads
        private byte[] ConvertPostedFileToByteArray(HttpPostedFileBase file)
        {
            byte[] imageByte = null;
            BinaryReader rdr = new BinaryReader(file.InputStream);
            imageByte = rdr.ReadBytes((int)file.ContentLength);
            return imageByte;
        }

    }
}