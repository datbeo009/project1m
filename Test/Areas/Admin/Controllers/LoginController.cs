using DataAccess.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Areas.Admin.Models;
using Test.Common;

namespace Test.Areas.Admin.Controllers
{
    //[Authorize]
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        //[AllowAnonymous]
        [HttpPost]
        public ActionResult LoginAdmin(LoginAdminModel model)
        {
            //if (ModelState.IsValid)
            //{
            UserBll ull = new UserBll();
            if (ull.Login(model.UserName, model.PassWord))
            {
                var user = ull.User(model.UserName);
                if (user.Role == 1)
                {
                    var adminLogin = new AdminLogin();
                    adminLogin.UserName = user.Username;
                    adminLogin.UserId = user.AccountID;

                    Session["AdminSession"] = adminLogin;
                    return Json(Url.Action("Index", "Product"));
                }
            }
            return Json(Url.Action("Index"));
        }


    }
}