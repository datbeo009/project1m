﻿using DataAccess.Entity;
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

        public List<Product> GetDetail(int id)
        {
            List<Product> lspro = new List<Product>();
            var orderDetail =  db.OrderDetails.Where(e => e.OrderId == id).ToList();
            var getAllProduct = db.Products.ToList();
            foreach (var item in orderDetail)
            {
                Product enti = new Product();
                var onePro = getAllProduct.SingleOrDefault(e => e.ProductID == item.ProductId);
                if (onePro != null)
                {
                    enti = onePro;
                    enti.Amount = item.Amount;
                    lspro.Add(enti);
                }
            }
            return lspro;
        }

        public bool CreateOrder(List<OrderDetail> details, Entity.Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            int orderId = order.OrderId;
            if (orderId > 0)
            {
                foreach(var item in details)
                {
                    item.OrderId = orderId;
                    db.OrderDetails.Add(item);
                }
                var isOk = db.SaveChanges();
                if (isOk > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
