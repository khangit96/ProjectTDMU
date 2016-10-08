using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShopThoiTrang
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {    
            /*Định nghĩa route*/
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*Phần Category*/
                routes.MapRoute(//Hiển thị danh sách Category
               name: "ManageCategory",
               url: "admin/quan-ly-category/",
               defaults: new { controller = "Category", action = "Index" }
                );
               routes.MapRoute(//Tạo mới Category
               name: "CreateCategory",
               url: "admin/quan-ly-category/tao-moi/",
               defaults: new { controller = "Category", action = "Create" }
               );
               routes.MapRoute(//Chỉnh sữa Category
             name: "EditCategory",
             url: "admin/quan-ly-category/chinh-sua/{id}/",
             defaults: new { controller = "Category", action = "Edit" }
             );
               routes.MapRoute(//Chi tiết Category
           name: "DetailCategory",
           url: "admin/quan-ly-category/chi-tiet/{id}/",
           defaults: new { controller = "Category", action = "Detail" }
           );
               routes.MapRoute(//Xoá Category
               name: "DeleteCategory",
               url: "admin/quan-ly-category/xoa/{id}/",
               defaults: new { controller = "Category", action = "Delete" }
               );

           /*Phần ProductCategory*/
               routes.MapRoute(//Hiển thị danh sách Product Category
                   name: "ManageProductCategory",
                   url: "admin/quan-ly-product-category/",
                   defaults: new { controller = "ProductCategory", action = "Index" }
                    );
               routes.MapRoute(//Tạo mới Product Category
               name: "CreateProductCategory",
               url: "admin/quan-ly-product-category/tao-moi/",
               defaults: new { controller = "ProductCategory", action = "Create" }
               );
               routes.MapRoute(//Chỉnh sữa ProductCategory
             name: "EditProductCategory",
             url: "admin/quan-ly-product-category/chinh-sua/{id}/",
             defaults: new { controller = "ProductCategory", action = "Edit" }
             );
               routes.MapRoute(//Chi tiết Product Category
           name: "DetailProductCategory",
           url: "admin/quan-ly-product-category/chi-tiet/{id}/",
           defaults: new { controller = "ProductCategory", action = "Detail" }
           );
               routes.MapRoute(//Xoá Product Category
               name: "DeleteProductCategory",
               url: "admin/quan-ly-product-category/xoa/{id}/",
               defaults: new { controller = "ProductCategory", action = "Delete" }
               );


            /*Phần Product*/
             
            routes.MapRoute(//Thêm mới
            name: "CreateProduct",
            url: "admin/quan-ly-product/them-moi/",
            defaults: new { controller = "Product", action = "CreateProduct" }
          );
            routes.MapRoute(//Chỉnh sửa
             name: "EditProduct",
             url: "admin/quan-ly-product/chinh-sua/{id}/",
             defaults: new { controller = "Product", action = "EditProduct" }
           );
              routes.MapRoute(//Hiển thị
              name: "SaveEditProduct",
              url: "admin/quan-ly-product/chinh-sua/luu/{id}",
              defaults: new { controller = "Product", action = "SaveEditProduct" }
            );
        
              routes.MapRoute(//Hiển thị
              name: "ManageProduct",
              url: "admin/quan-ly-product/",
              defaults: new { controller = "Product", action = "Index" }
            );
              routes.MapRoute(//Xoá
                name: "DeleteProduct",
                url: "admin/quan-ly-product/xoa/{id}/",
                defaults: new { controller = "Product", action = "DeleteProduct" }
              );
            /*Phần Login,Logout*/
              routes.MapRoute(
              name: "logout",
              url: "admin/dang-xuat/",
              defaults: new { controller = "Login", action = "logout" }
          );
            routes.MapRoute(
            name: "checkLogin",
            url: "admin/kiem-tra-dang-nhap/",
            defaults: new { controller = "Login", action = "checkLogin" }
        );
            routes.MapRoute(
              name: "Login",
              url: "admin/dang-nhap/",
              defaults: new { controller = "Login", action = "Index"}
          );

        /*Phần User*/
            routes.MapRoute(
            name: "ManageUser",
            url: "admin/quan-ly-user/",
            defaults: new { controller = "User", action = "Index" }
        );
            routes.MapRoute(
          name: "CreateUser",
          url: "admin/quan-ly-user/them-moi/",
          defaults: new { controller = "User", action = "Create" }
      );
            routes.MapRoute(
          name: "DeleteUser",
          url: "admin/quan-ly-user/xoa/{id}/",
          defaults: new { controller = "User", action = "Detele" }
      );
            routes.MapRoute(
          name: "EditUser",
          url: "admin/quan-ly-user/chinh-sua/{id}/",
          defaults: new { controller = "User", action = "Edit" }
      );
            routes.MapRoute(
          name: "DetailUser",
          url: "admin/quan-ly-user/chi-tiet/{id}/",
          defaults: new { controller = "User", action = "Detail" }
      );
            //Mặc định
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
