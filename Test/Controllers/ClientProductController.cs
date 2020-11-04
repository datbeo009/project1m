using DataAccess.DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Controllers
{
    public class ClientProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        ProductBll proBll = new ProductBll();
        public string Gets()
        {
            return JsonConvert.SerializeObject(proBll.Gets());
        }
    }
}