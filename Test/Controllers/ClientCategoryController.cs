using DataAccess.DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Controllers
{
    public class ClientCategoryController : Controller
    {
        // GET: ClientCategory
        public ActionResult Index(int id)
        {

            return View();
        }
        CategoryBll cll = new CategoryBll();
        public string Gets()
        {
            return JsonConvert.SerializeObject(cll.Gets());
        }
    }
}