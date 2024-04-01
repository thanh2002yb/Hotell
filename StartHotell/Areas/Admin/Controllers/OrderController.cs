using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StartHotell.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        // GET: Admin/Order
        [HttpGet]
        public ActionResult Index()
        {
            var dao = new OrderDao();
            var moder = dao.getListAllPaging();
            return View(moder);

        }
        public ActionResult Delete(int id)
        {
            new OrderDao().Delete(id);

            return RedirectToAction("Index");
        }
    }
}