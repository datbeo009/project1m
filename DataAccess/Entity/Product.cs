namespace DataAccess.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int ProductID { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public int? Price { get; set; }

        public int? CategoryID { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }

        public string Image { get; set; }
        public string ListImage { get; set; }
        public bool Status { get; set; }
        public bool Active { get; set; }


        public string CategoryName { get; set; }


    }
}
