namespace DataAccess.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        public int CategoryID { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }
        public int ParentID { get; set; }
        public bool Status { get; set; }
        public bool Active { get; set; }

        public List<Category> lsChild { get; set; }
    }
}
