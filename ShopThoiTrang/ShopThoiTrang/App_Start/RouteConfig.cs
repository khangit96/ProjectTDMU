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


            routes.MapRoute(//Hiển thị danh sách sản phẩm trong giỏ hàng
             name: "ManageInvoice",
             url: "admin/quan-ly-hoa-don/",
             defaults: new { controller = "Invoice", action = "Index" }

              );

            routes.MapRoute(//Hiển thị danh sách sản phẩm trong giỏ hàng
             name: "InvoiceDetail",
             url: "admin/hoa-don/chi-tiet-{ID}/",
             defaults: new { controller = "Invoice", action = "Detail" }

              );

            routes.MapRoute(//Hiển thị danh sách sản phẩm trong giỏ hàng
             name: "Statistics",
             url: "admin/san-pham/thong-ke/",
             defaults: new { controller = "Product", action = "Statistics" }

              );
            routes.MapRoute(//Hiển thị danh sách sản phẩm trong giỏ hàng
             name: "SearchProduct",
             url: "san-pham/tim-kiem/",
             defaults: new { controller = "Home", action = "SearchProduct" }

              );
            /*Phần Giỏ Hàng*/
            routes.MapRoute(//Hiển thị danh sách sản phẩm trong giỏ hàng
              name: "ViewCart",
              url: "san-pham/gio-hang",
              defaults: new { controller = "Cart", action = "Index" }

               );
            routes.MapRoute(//Hiển thị danh sách sản phẩm trong giỏ hàng
            name: "DeleteCart",
            url: "san-pham/gio-hang/xoa-{id}/",
            defaults: new { controller = "Cart", action = "DeleteCart" }

             );
           routes.MapRoute(//Hiển thị danh sách sản phẩm trong giỏ hàng
           name: "AddToCart",
           url: "san-pham/gio-hang/them/{id}/",
           defaults: new { controller = "Cart", action = "AddToCart" }

            );

           routes.MapRoute(//Hiển thị danh sách sản phẩm trong giỏ hàng
             name: "Checkout",
             url: "san-pham/gio-hang/dat-hang/",
             defaults: new { controller = "Cart", action = "Checkout" }
             );
           routes.MapRoute(//Hiển thị danh sách sản phẩm trong giỏ hàng
            name: "Invoice",
            url: "san-pham/dat-hang/hoa-don/",
            defaults: new { controller = "Cart", action = "SaveInvoice" }
            );
            /*Phần Home*/
            routes.MapRoute(//Hiển thị danh sách Product Category
                name: "ViewByProductCategory",
                url: "{productCateogryname}-{productCategoryID}/",
                defaults: new { controller = "Home", action = "ViewByProductCategory" }

                 );
              routes.MapRoute(//Xem chi tiết sản phẩm
              name: "ViewProductDetail",
             url: "san-pham/chi-tiet-{id}/",
            defaults: new { controller = "Home", action = "ViewProductDetail" }
             );

           /*Phần ProductCategory*/
               routes.MapRoute(//Hiển thị danh sách Product Category
                   name: "ManageProductCategory",
                   url: "admin/quan-ly-product-category/",
                   defaults: new { controller = "ProductCategory", action = "Index",Page=1}
                    );
               routes.MapRoute(//Tạo mới Product Category
               name: "CreateProductCategory",
               url: "admin/quan-ly-product-category/them-moi/",
               defaults: new { controller = "ProductCategory", action = "CreateProductCategory" }
               );

               routes.MapRoute(//Tạo mới Product Category
                 name: "SaveCreateProductCategory",
                 url: "admin/quan-ly-product-category/them-moi/luu",
                 defaults: new { controller = "ProductCategory", action = "SaveCreateProductCategory" }
                 );
               routes.MapRoute(//Chỉnh sữa ProductCategory
             name: "EditProductCategory",
             url: "admin/quan-ly-product-category/chinh-sua/{id}/",
             defaults: new { controller = "ProductCategory", action = "EditProductCategory" }
             );
               routes.MapRoute(//Chỉnh sữa ProductCategory
                  name: "SaveEditProductCategory",
                  url: "admin/quan-ly-product-category/chinh-sua/luu/{id}/",
                  defaults: new { controller = "ProductCategory", action = "SaveEditProductCategory" }
                  );
               routes.MapRoute(//Xoá Product Category
               name: "DeleteProductCategory",
               url: "admin/quan-ly-product-category/xoa/{id}/",
               defaults: new { controller = "ProductCategory", action = "DeleteProductCategory" }
               );


            /*Phần Product*/

          
            routes.MapRoute(//Thêm mới
            name: "CreateProduct",
            url: "admin/quan-ly-product/them-moi/",
            defaults: new { controller = "Product", action = "CreateProduct" }
          );
            routes.MapRoute(//Thêm mới
            name: "SaveCreateProduct",
            url: "admin/quan-ly-product/them-moi/luu/",
            defaults: new { controller = "Product", action = "SaveCreateProduct" }
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
              defaults: new { controller = "Product", action = "Index",Page=1 }
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
            url: "admin/quan-ly-admin/",
            defaults: new { controller = "Admin", action = "Index" }
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
                name: "Defaultffs",
                url: "trang-chu/",
                defaults: new { controller = "Home", action = "Index"}
            );
           
            routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}",
            defaults: new { controller = "Home", action = "Index" }
        );
        }
    }
}
