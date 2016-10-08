using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopThoiTrang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Checkout")]
    public partial class Checkout
    {
        public int id { get; set; }
        [StringLength(50)]
        public string customerName { get; set; }
        public int? quantity { get; set; }
    }
}