using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Areas.Admin.Controllers
{
    public class FileController : Controller
    {
        public JsonResult UploadFile()
        {
            // check if the user selected a file to upload
            if (Request.Files.Count > 0)
            {
                try
                {
                    var dateCreate = DateTime.Now.ToString("yyyyMMddHHmmss");

                    HttpFileCollectionBase files = Request.Files;

                    HttpPostedFileBase file = files[0];
                    string fileName =  dateCreate + "_" + file.FileName;

                    // create the uploads folder if it doesn't exist
                    var pathSave = Server.MapPath("~/uploads/");
                    if(!Directory.Exists(pathSave))
                    {
                        Directory.CreateDirectory(pathSave);
                    }
                    // var pathsv = Server.MapPath("");


                    string path = Path.Combine(Server.MapPath("~/uploads/"), fileName);
                    // string path = Path.Combine(@"C:\Users\ThinkPad X1\Desktop\test-prj", fileName);

                    // save the file
                    file.SaveAs(path);
                    return Json("/uploads/" + fileName);
                }

                catch (Exception e)
                {
                    return Json("error" + e.Message);
                }
            }

            return Json("no files were selected !");
        }
    }
}