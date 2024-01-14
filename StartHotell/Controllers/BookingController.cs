using Microsoft.Ajax.Utilities;
using Model.DAO;
using Model.FE;
using StartHotell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StartHotell.Controllers
{
    public class BookingController : Controller
    {
        // GET: Booking
        private const string BookingSession = "BookingSession";
        public ActionResult Index()
        {
            var booking = Session[BookingSession];
            var list = new List<BookingModel>();
            if (list != null)
            {
                list = (List<BookingModel>)booking;
            }
            return View(list);
        }

        public ActionResult AddItemt(long ProductId , int Quantity)
        {
            var booking = Session[BookingSession];
            var product = new ProductDao().ViewDetail(ProductId);
            if (booking != null)
            {
                var list = (List<BookingModel>)booking;
                if (list.Exists(x => x.Product.ID == ProductId))
                {
                    foreach(var item in list)
                    {
                        if (item.Product.ID == ProductId)
                        {
                            item.Quantity += Quantity;
                        }                 
                    }
                }
                else
                {
                    var item = new BookingModel();
                    item.Product = product;
                    item.Quantity = Quantity;
                    list.Add(item);
                }
                Session[BookingSession] = list;
            }
            else
            {
                var item = new BookingModel();
                item.Product = product;
                item.Quantity = Quantity;
                var list = new List<BookingModel>();
                list.Add(item);
                Session[BookingSession] = list;
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Paymen()
        {
            var booking = Session[BookingSession];
            var list = new List<BookingModel>();
            if (booking != null)
            {
                list = (List<BookingModel>)booking;
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult Paymen(DateTime checkin ,DateTime checkout,string adult ,string Child )
        {
            //if (User.Identity.IsAuthenticated)
            var book = new Book();
            book.Check_In = checkin;
            book.Check_out = checkout;
            book.Adult = adult;
            book.Child = Child;
            decimal total = 0;
            try
            {
                var id = new BookingDao().Insert(book);
                var list = (List<BookingModel>)Session[BookingSession];
                var detail = new BookingDetailDao();
                foreach (var item in list)
                {
                    var bookingdetail = new BookDetail();
                    bookingdetail.ProductID = item.Product.ID;
                    bookingdetail.BookID = id;
                    bookingdetail.Price = item.Product.Price;
                    bookingdetail.Quantity = item.Product.Quantity;
                    detail.Insert(bookingdetail);

                    total += (item.Product.Price.GetValueOrDefault(0) * item.Quantity);
                }
            }
            catch(Exception ex)
            {
                return Redirect("/loi-thanh-toan");
            }
           
            return Redirect("/hoan-thanh");
        }
        public ActionResult Success()
        {
            return View();
        }
    }
}