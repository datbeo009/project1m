using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAL
{
    public class ProductBll
    {

        WebModel _dbContext = null;
        public ProductBll()
        {
            _dbContext = new WebModel();
        }

        public List<Product> Gets()
        {
            var lsProduct = _dbContext.Products.Where(e => e.Status == true).ToList();
            var lsCate = _dbContext.Categories.ToList();
            List<Product> lsPro = new List<Product>();
            foreach (var item in lsProduct)
            {
                Product enti = item;
                enti.CategoryName = "Chưa có Category";
                var cate = lsCate.Where(e => e.CategoryID == item.CategoryID).FirstOrDefault();
                if (cate != null)
                {
                    enti.CategoryName = cate.CategoryName;

                }
                lsPro.Add(enti);
            }
            return lsPro;
        }

        public bool CreateOrUpdateProduct(Product entity)
        {
            try
            {
                if (entity.ProductID == 0)
                {
                    _dbContext.Products.Add(entity);
                }
                else
                {
                    var product = _dbContext.Products.Find(entity.ProductID);
                    product.ProductName = entity.ProductName;
                    product.Price = entity.Price;
                    product.Image = entity.Image;
                    product.LastModifiedDate = entity.LastModifiedDate;
                    product.ListImage = entity.ListImage;
                    product.Active = entity.Active;
                    product.Status = entity.Status;
                }
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool DeleteProduct(int id)
        {
            try
            {
                var product = _dbContext.Products.Find(id);
                product.Status = false;
                _dbContext.SaveChanges();
                // _dbContext.Products.Remove(_dbContext.Products.Find(id));
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public Product GetById(int id)
        {
            return _dbContext.Products.Find(id);
        }
        public bool CheckExistProductName(string name)
        {
            return _dbContext.Products.Any(e => e.ProductName == name);
        }
    }
}
