namespace ShopThoiTrang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Descriptions { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImages { get; set; }

        public decimal? Price { get; set; }

        public int? Quantity { get; set; }

        public int? ParentID { get; set; }

        [StringLength(250)]
        public string MetaTtile { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        public DateTime? CreatedDate { get; set; }

        public bool? Status { get; set; }

        [StringLength(10)]
        public string TopNew { get; set; }

        public decimal? DecreasePrice { get; set; }

        [StringLength(10)]
        public string TopDecrease { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
        public Product(String productName,int parentID,decimal productPrice,String productImage,String productDescription,String isTopDescrease,decimal decreasePrice,String isTopNew)
        {
            this.Name = productName;
            this.ParentID = parentID;
            this.Price = productPrice;
            this.Image = productImage;
            this.Descriptions = productDescription;
            this.TopDecrease = isTopDescrease;
            this.DecreasePrice = decreasePrice;
            this.TopNew = isTopNew;


        }
        public Product()
        {

        }

    }
}
