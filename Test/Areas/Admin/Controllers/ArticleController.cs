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
    public class ArticleController : BaseController
    {
        // GET: Admin/Article
        public ActionResult Index()
        {
            return View();
        }
        ArticleBll artBll = new ArticleBll();

        [HttpGet]
        public JsonResult Gets()
        {
            return Json(artBll.Gets(), JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public bool CreateOrUpdate(ArticleModel model)
        {
            Article entity = new Article();
            if (artBll.CheckExistTitle(model.Title))
            {
                return false;
            }
            entity.ID = model.ID;
            entity.Title = model.Title;
            entity.Content = model.Content;
            entity.ListImage = model.ListImage;
            entity.Image = model.Image;
            entity.CreatedDate = model.CreatedDate;
            entity.Status = 1;
    
            return artBll.CreateOrUpdateArticle(entity);
        }
        public bool Delete(int id)
        {
            return artBll.DeleteArticle(id);
        }
    }
}