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
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index()
        {
            //ShoppingCartController ctroller = new ShoppingCartController();
            //ctroller.AddToCart(1);

            //var abc = ctroller.GetCart();

            return View();
        }
        ProductBll proBll = new ProductBll();

        [HttpGet]
        public JsonResult Gets()
        {
            return Json(proBll.Gets(),JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public bool CreateOrUpdate(ProductModel model)
        {
            Product entity = new Product();
            if (proBll.CheckExistProductName(model.ProductName))
            {
                return false;
            }
            entity.ProductID = model.ProductID;
            entity.ProductName = model.ProductName;
            entity.CategoryID = model.CategoryID;
            entity.Description = model.Description;
            entity.ListImage = model.ListImage;
            entity.Price = model.Price;
            entity.Status = true;
            entity.Active = model.Active;
            if (model.ProductID > 0)
            {
                entity.LastModifiedDate = DateTime.Now;
            }
            else
            {
                entity.CreatedDate = DateTime.Now;
            }

            return proBll.CreateOrUpdateProduct(entity);
        }

        [HttpPost]
        public bool Delete(int id)
        {
            return proBll.DeleteProduct(id);
        }
    }
}