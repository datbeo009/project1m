using DataAccess.DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Controllers
{
    public class ClientArticleDetailController : Controller
    {
        // GET: ClientArticleDetail
        public ActionResult Index(int id)
        {
            ViewBag.TitleId = id;
            return View();
        }
        ArticleBll bll = new ArticleBll();
        public string LoadArticle(int id)
        {
            return JsonConvert.SerializeObject(bll.GetById(id));
        }
    }
}