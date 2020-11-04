using DataAccess.DAL;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Areas.Admin.Models;

namespace Test.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View();
        }
        CategoryBll bll = new CategoryBll();


        [HttpGet]
        public JsonResult Gets()
        {
            return Json(bll.Gets(), JsonRequestBehavior.AllowGet);
        }

        public bool CreateOrUpdate(CategoryModel model)
        {
            if (bll.CheckExistCateName(model.CategoryName))
            {
                return false;
            }
            Category entity = new Category();
            entity.CategoryID = model.CategoryID;
            entity.CategoryName = model.CategoryName;
            entity.ParentID = model.ParentID;
            entity.Status = true;
            entity.Active = model.Active;
            return bll.CreateOrEdit(entity);
        }
        [HttpPost]
        public bool Delete(int id)
        {
            return bll.DeleteCategory(id);
        }
    }
}