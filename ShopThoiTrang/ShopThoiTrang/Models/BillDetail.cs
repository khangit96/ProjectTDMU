using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopThoiTrang.Models
{
      [Table("BillDetail")]
    public partial class BillDetail
    {
          public int ID { get; set; }
          public int ProductID { get; set; }
          public decimal Price { get; set; }
          public int BillID { get; set; }
          public int Quantity { get; set; }
          public BillDetail(int productID,decimal price,int billID,int quantity)
          {
              this.ProductID = productID;
              this.Price = price;
              this.BillID = billID;
              this.Quantity = quantity;
          }
          public BillDetail()
          {

          }
    }
}