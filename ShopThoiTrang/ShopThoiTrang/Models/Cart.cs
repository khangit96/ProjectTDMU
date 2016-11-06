using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopThoiTrang.Models
{
    public class Cart
    {
        public Product product=new Product();
        public int quantity;
        public decimal totalPrice;
        public int ID;
        public Cart(int ID,Product product,int quantity,decimal totalPrice)
        {
            this.ID = ID;
            this.product = product;
            this.quantity = quantity;
            this.totalPrice = totalPrice;
        }
        public Cart()
        { }
    }
}