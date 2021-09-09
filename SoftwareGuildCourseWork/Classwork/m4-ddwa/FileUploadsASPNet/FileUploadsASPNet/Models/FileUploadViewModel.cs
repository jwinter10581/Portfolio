using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileUploadsASPNet.Models
{
    public class FileUploadViewModel
    {
        public HttpPostedFileBase UploadedFile { get; set; }
    }

}