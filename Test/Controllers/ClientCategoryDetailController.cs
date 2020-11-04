using DataAccess.DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Controllers
{
    public class ClientCategoryDetailController : Controller
    {
        // GET: ClientCategoryDetail
        public ActionResult Index(int id)
        {
            ViewBag.CatId = id;
            return View();
        }
        CategoryBll cll = new CategoryBll();
        public string LoadCategory(int id)
        {
            return JsonConvert.SerializeObject(cll.GetById(id));
        }
    }
}