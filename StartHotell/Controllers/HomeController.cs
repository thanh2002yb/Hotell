using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StartHotell.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var product = new ProductDao();
            ViewBag.Product = product.ListNewProduct(4);
            return View();
        }
        public ActionResult Menu()
        {
            var model = new MenuDao().GetListByGroupId(1);
            return PartialView(model);
        }
    }
}