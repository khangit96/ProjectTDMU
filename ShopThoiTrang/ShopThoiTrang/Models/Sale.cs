using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopThoiTrang.Models
{
    public class Sale
    {
        public int quantity;
        public Product product;
        public Sale(Product product,int quantity)
        {
            this.product = product;
            this.quantity = quantity;
        }
        public Sale()
        {

        }
    }
}