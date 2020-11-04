using DataAccess.DAL;
using DataAccess.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        // GET: Admin/Order
        public ActionResult Index()
        {
            return View();
        }

        DataAccess.DAL.Order bll = new DataAccess.DAL.Order();
        public string Gets()
        {
            return JsonConvert.SerializeObject(bll.GetAll());
        }

        public bool ApprovedOrder(int id, bool isDenied)
        {
            return bll.ApproveOrder(id, isDenied);
        }
        public string GetDetail(int id)
        {
            return JsonConvert.SerializeObject(bll.GetDetail(id));
        }

    }
}