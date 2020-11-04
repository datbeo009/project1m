using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAL
{
    public class CategoryBll
    {


        WebModel _dbContext = null;
        public CategoryBll()
        {
            _dbContext = new WebModel();
        }

        public List<Category> Gets()
        {
            var allCate = _dbContext.Categories.ToList();
            List<Category> lsCate = new List<Category>();
            var parCate = allCate.Where(e => e.ParentID == 0).ToList();
            
            foreach(var item in parCate)
            {
                Category entity = new Category();
                entity.CategoryID = item.CategoryID;
                entity.CategoryName = item.CategoryName;
                entity.ParentID = item.ParentID;
                entity.Active = item.Active;
                entity.Status = item.Status;
                var lsChild = new List<Category>();
                lsChild = allCate.Where(e => e.ParentID == item.CategoryID).ToList();
                entity.lsChild = lsChild;
                lsCate.Add(entity);
            }
            return lsCate;
        }


        public bool CreateOrEdit(Category entity)
        {
            try
            {
                if (entity.CategoryID == 0)
                {
                    _dbContext.Categories.Add(entity);
                }
                else
                {
                    var category = _dbContext.Categories.Find(entity.CategoryID);
                    category.CategoryName = entity.CategoryName;
                    category.lsChild = entity.lsChild;
                    category.ParentID = entity.ParentID;
                    category.Status = entity.Status;
                    category.Active = entity.Active;
                }
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }
        public bool DeleteCategory(int id)
        {
            try
            {
                var category = _dbContext.Categories.Find(id);
                category.Status = false;
                _dbContext.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }

        }
        public Category GetById(int id)
        {
            return _dbContext.Categories.Find(id);
        }
        public bool CheckExistCateName(string name)
        {
            return _dbContext.Categories.Any(e => e.CategoryName == name);
        }


    }
}
