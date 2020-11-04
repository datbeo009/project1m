using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAL
{
    public class Order
    {
        WebModel db = new WebModel();
        public List<Entity.Order> GetAll()
        {
            return db.Orders.ToList();
        }

        public bool ApproveOrder(int id, bool isDenied)
        {
            var order = db.Orders.Find(id);
            if (order != null)
            {
                if (order.Status == 0)
                {
                    order.Status = isDenied ? 0 : 1;
                }
                else if (order.Status == 1)
                {
                    order.Status = isDenied ? 3 : 4;
                }
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<OrderDetail> GetDetail(int id)
        {
            return db.OrderDetails.Where(e => e.OrderId == id).ToList();

        }


    }
}
