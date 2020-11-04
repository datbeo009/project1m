using DataAccess.DAL;
using DataAccess.Entity;
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
        public  List<DataAccess.Entity.Order> Gets()
        {
            return bll.GetAll();
        }

        public bool ApprovedOrder(int id, bool isDenied)
        {
            return bll.ApproveOrder(id, isDenied);
        }
        public List<OrderDetail> GetDetail(int id)
        {
            return bll.GetDetail(id);
        }

    }
}