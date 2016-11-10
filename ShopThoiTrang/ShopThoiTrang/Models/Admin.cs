namespace ShopThoiTrang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
       [Key]
        public int id { get; set; }
        public Admin(String username,String password,String role)
        {
            this.username = username;
            this.password = password;
            this.role = role;
        }
        public Admin()
        { }
        [StringLength(50)]
        public string username { get; set; }

        [StringLength(50)]
        public string password { get; set; }
        
        [StringLength(5)]
        public string role { get; set; }
    }
}
