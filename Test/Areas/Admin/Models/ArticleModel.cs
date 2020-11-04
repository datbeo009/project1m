using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Areas.Admin.Models
{
    public class ArticleModel
    {
        public int ID { get; set; }

       
        public string Title { get; set; }

        public string Content { get; set; }

        
        public string Image { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int Status { get; set; }
        public string ListImage { get; set; }
    }
}