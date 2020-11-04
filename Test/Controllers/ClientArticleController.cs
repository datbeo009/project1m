using DataAccess.DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Controllers
{
    public class ClientArticleController : Controller
    {
        // GET: ClientArticle
        public ActionResult Index()
        {
            return View();
        }
        ArticleBll bll = new ArticleBll();

        public string Gets()
        {
            return JsonConvert.SerializeObject(bll.Gets());
        }
    }
}