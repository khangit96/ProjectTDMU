using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopThoiTrang.Models
{
    [Table("Bill")]
    public partial class Bill
    {
        public int ID { get; set; }

        public int CustomerID { get; set; }
        public decimal TotalPrice{get;set;}
        public Bill(int customerID,decimal totalPrice )
        {
            this.CustomerID = customerID;
            this.TotalPrice = totalPrice;
        }
        public Bill()
        {

        }

    }
}