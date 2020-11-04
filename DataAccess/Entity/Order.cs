using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace DataAccess.Entity
{
    [Table("Order")]
    public class Order
    {
        public int OrderId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public int UserId { get; set; }
        public string Fee { get; set; }
        public string ShipMethod { get; set; }
        public int Status { get; set; }
        public int TotalPrice { get; set; }
    }
}
