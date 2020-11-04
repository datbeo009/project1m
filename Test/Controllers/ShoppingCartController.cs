using DataAccess.DAL;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Areas.Admin.Controllers;

namespace Test.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }


        public List<Product> GetAllProuctByCart()
        {
            List<Product> lsAll = new List<Product>();
            var allCart = (List<CartSession>)Session["Cart"];
            if (allCart != null)
            {
                ProductBll dalPro = new ProductBll();
                var getAllProduct = dalPro.Gets();
                foreach (var item in allCart)
                {
                    var getpro = getAllProduct.SingleOrDefault(e => e.ProductID == item.ProductId);
                    if (getpro != null)
                    {
                        lsAll.Add(getpro);
                    }
                }
            }
            return lsAll;

        }

        public bool AddToCart(int productId, int amount)
        {
            if (productId == 0 || amount == 0)
            {
                return false;
            }
            var allCart = (List<CartSession>)Session["Cart"];
            CartSession cart = new CartSession();
            List<CartSession> lsCart = new List<CartSession>();
            cart.Amount = amount;
            cart.ProductId = productId;
            if (allCart == null)
            {
                lsCart.Add(cart);
                Session["Cart"] = lsCart;
                return true;
            }
            var alreadyHas = allCart.SingleOrDefault(e => e.ProductId == productId);
            if (alreadyHas != null)
            {
                alreadyHas.Amount = alreadyHas.Amount + amount;
                Session["Cart"] = allCart;
                return true;
            }
            allCart.Add(cart);
            Session["Cart"] = allCart;
            return true;
        }

        public int CartCount()
        {
            var allCart = (List<CartSession>)Session["Cart"];
            return allCart == null ? 0 : allCart.Count;
        }

    }

    public class CartSession
    {
        public int ProductId { get; set; }
        public int Amount { get; set; }
    }
}