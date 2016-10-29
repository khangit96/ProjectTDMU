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
        public Cart(Product product,int quantity,decimal totalPrice)
        {
            this.product = product;
            this.quantity = quantity;
            this.totalPrice = totalPrice;
        }
        public Cart()
        { }
    }
}