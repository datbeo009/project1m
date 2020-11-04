using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAL
{
    public class ArticleBll
    {

        WebModel _dbContext = null;
        public ArticleBll()
        {
            _dbContext = new WebModel();
        }

        public List<Article> Gets()
        {

            return _dbContext.Article.Where(e => e.Status == 1).ToList();
        }

        public bool CreateOrUpdateArticle(Article entity)
        {
            try
            {
                if (entity.ID == 0)
                {
                    _dbContext.Article.Add(entity);
                }
                else
                {
                    var article = _dbContext.Article.Find(entity.ID);
                    article.Title = entity.Title;
                    article.Image = entity.Image;
                    article.ListImage = entity.ListImage;
                    article.CreatedDate = entity.CreatedDate;
                    article.Content = entity.Content;
                }
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool DeleteArticle(int id)
        {

            try
            {
                var article = _dbContext.Article.Find(id);
                article.Status = 0;
                _dbContext.SaveChanges();
                //_dbContext.Article.Remove(_dbContext.Article.Find(id));
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }


        public Article GetById(int id)
        {
            return _dbContext.Article.Find(id);
        }
        public bool CheckExistTitle(string title)
        {
            return _dbContext.Article.Any(e => e.Title == title);
        }
    }
}

