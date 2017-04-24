using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibrarySystem.Models
{
    public class FileHandler
    {

        public static bool isValidFile(HttpPostedFileBase File, string[] AllowedTypes)
        {
            return (File != null && File.ContentLength > 0 && AllowedTypes.Any(m => m == File.ContentType));
        }

        public static string FileSave(HttpPostedFileBase file, string Location, Controller controller)
        {
            var fileName = Path.GetFileName(file.FileName).Replace(" ", "_");
            var path = Path.Combine(controller.Server.MapPath(Location), fileName);
            file.SaveAs(path);
            return Location + "/" + fileName;
        }
    }
}