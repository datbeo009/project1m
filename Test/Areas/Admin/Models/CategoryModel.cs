using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Areas.Admin.Models
{
    public class CategoryModel
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }
        public int ParentID { get; set; }
        public bool Status { get; set; }
        public bool Active { get; set; }
    }
}