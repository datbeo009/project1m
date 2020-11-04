namespace DataAccess.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Review")]
    public partial class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDReview { get; set; }

        [StringLength(100)]
        public string Content { get; set; }

        public int? Rating { get; set; }

        public int? ProductID { get; set; }
    }
}
