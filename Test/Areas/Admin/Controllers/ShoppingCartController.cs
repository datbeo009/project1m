using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Areas.Admin.Models;
namespace Test.Areas.Admin.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: Admin/ShoppingCart
        public ActionResult Index()
        {
            return View();
        }

        public void AddToCart(int productId)
        {
            CartModel model = new CartModel();
            model.ProductId = productId;
            Session["CartSession"] = model;
        }


        public string GetCart()
        {
            return Session["CartSession"].ToString();
        }
    }
}