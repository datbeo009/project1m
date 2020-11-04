using DataAccess.DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Controllers
{
    public class ClientProductDetailController : Controller
    {
        // GET: ClientProductDetail
        public ActionResult Index(int id)
        {
            ViewBag.ProID = id;
            return View();
        }
        ProductBll proll = new ProductBll();
        public string LoadProduct(int id)
        {
            return JsonConvert.SerializeObject(proll.GetById(id));
        }
    }
}