using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopThoiTrang.Models
{
     [Table("Customer")]
    public partial class Customer
    {
          public int ID { get; set; }

          [StringLength(50)]
          public string CustomerName { get; set; }

          [StringLength(100)]
          public string CustomerAddress { get; set; }

          [StringLength(50)]
          public string CustomerEmail { get; set; }

          [StringLength(30)]
          public string CustomerPhone { get; set; }
        public Customer(String customerName,String customerAddress,String customerEmail,String customerPhone )
        {
            this.CustomerName = customerName;
            this.CustomerAddress = customerAddress;
            this.CustomerEmail = customerEmail;
            this.CustomerPhone= customerPhone;

        }
        public Customer()
        {

        }

    }
}