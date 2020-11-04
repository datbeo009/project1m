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
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            return View();
        }
        UserBll ull = new UserBll();

        [HttpGet]
        public JsonResult Gets()
        {
            return Json(ull.Gets(), JsonRequestBehavior.AllowGet);
        }
        //[HttpPost]
        //public bool CreateOrUpdate(AccountModel model )
        //{
        //    Account entity = new Account();
        //    if(ull.CheckExistUserName(model.Username))
        //    {
        //        return false;
        //    }
        //    entity.AccountID = model.AccountID;
        //    entity.Username = model.Username;
        //    entity.Password = model.Password;
        //    entity.Phone = model.Phone;
        //    entity.Address = model.Address;
        //    entity.Gender = model.Gender;

        //    if(model.AccountID > 0)
        //    {
        //        entity.LastModifiedDate = DateTime.Now;
        //    }
        //    else
        //    {
        //        entity.CreatedDate = DateTime.Now;
        //    }
        //    return ull.CreateOrUpdateUser(entity);
        //}
        [HttpPost]
        public bool Register(AccountModel model)
        {
            Account entity = new Account();
            if(ull.CheckExistUserName(model.Username))
            {
                return false;
            }
            //if (model.Password != model.ConfirmPassword)
            //{
            //    return false;
            //}
            entity.AccountID = model.AccountID;
            entity.Username = model.Username;
            entity.Password = model.Password;
            //entity.ConfirmPassword = model.ConfirmPassword;
            entity.Phone = model.Phone;
            entity.Address = model.Address;
            entity.Gender = model.Gender;
            entity.Status = true;
            entity.Role = model.Role;
            if (model.AccountID > 0)
            {
                entity.LastModifiedDate = DateTime.Now;
            }
            else
            {
                entity.CreatedDate = DateTime.Now;
            }
            return ull.Register(entity);
        }
        [HttpPost]
        public  bool Delete(int id)
        {
            return ull.DeleteUser(id);
        }
     
       
    }
}