using DataAccess.DAL;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Controllers
{
    public class ClientLoginController : Controller
    {
        // GET: ClientLogin
        public ActionResult Index()
        {
            return View();
        }

        UserBll bll = new UserBll();
        public bool Register(string username, string password)
        {
            Account accEntity = new Account();
            if (bll.CheckExistUserName(username))
            {
                return false;
            }
            accEntity.Username = username;
            accEntity.Password = password;
            accEntity.LastModifiedDate = DateTime.Now;
            accEntity.Role = 2;
            accEntity.Status = true;

            return bll.Register(accEntity);

        }

        public bool ClientLogin(string username, string password)
        {
            if (bll.Login(username,password))
            {
                var client = bll.User(username);
                if (client != null)
                {
                    if (client.Role == 2)
                    {
                        ClientLogin sess = new ClientLogin();
                        sess.UserId = client.AccountID;
                        sess.UserName = username;
                        Session["ClientLogin"] = sess;
                        return true;
                    }
                }
            }
            return false;
        }
    }
   



    public class ClientLogin
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}