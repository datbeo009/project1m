namespace DataAccess.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Article")]
    public partial class Article
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public string Content { get; set; }

        [StringLength(50)]
        public string Image { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int Status { get; set; }
        public string ListImage { get; set; }
    }
}
