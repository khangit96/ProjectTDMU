using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopThoiTrang.Models;

namespace ShopThoiTrang.Controllers
{
    public class InvoiceController : Controller
    {

        DBShop db = new DBShop();
        public ActionResult Index()
        {
            ViewBag.invoiceList = db.Bills.ToList();
            return View();
        }
        public ActionResult Detail(int ID)
        {
            var invoice = db.Bills.Find(ID);
            var customer=db.Customers.Find(invoice.CustomerID);
            var billDetailList = db.BillDetails.Where(x => x.BillID == invoice.ID).ToList();

            ViewBag.invoice = invoice;
            ViewBag.customer = customer;
            ViewBag.billDetailList = billDetailList;
            
            return View();
        }
	}
}