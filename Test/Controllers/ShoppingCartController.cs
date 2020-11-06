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
        DataAccess.DAL.Order bll = new DataAccess.DAL.Order();
        // 1 thành công
        //2 thất bại
        //3 chưa đăng nhập
        public int SaveOrder(OrderSave model)
        {
            var user = (ClientLogin)Session["ClientLogin"];
            if (user != null)
            {
                var cart = model.Product;
                var orderEnti = model.OrderInfo;

                List<OrderDetail> lsDetail = new List<OrderDetail>();
                DataAccess.Entity.Order order = new DataAccess.Entity.Order();
                order.Email = orderEnti.Email;
                order.Phone = orderEnti.Phone;
                order.Name = orderEnti.Name;
                order.Address = orderEnti.Address;
                order.Note = orderEnti.Note;
                order.Fee = orderEnti.Fee;
                order.ShipMethod = orderEnti.ShipMethod;
                order.TotalPrice = orderEnti.TotalPrice;


                foreach (var item in cart)
                {
                    OrderDetail enti = new OrderDetail();
                    enti.ProductId = item.ProductId;
                    enti.Amount = item.Amount;
                    lsDetail.Add(enti);
                }

                return bll.CreateOrder(lsDetail, order) ? 1 : 2;
            }
            return 3;
        }
    }

    public class CartSession
    {
        public int ProductId { get; set; }
        public int Amount { get; set; }
    }

    public class OrderModel
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public string Fee { get; set; }
        public string ShipMethod { get; set; }
        public int TotalPrice { get; set; }
    }

    public class OrderSave
    {
        public List<CartSession> Product { get; set; }
        public OrderModel OrderInfo { get; set; }
    }
}