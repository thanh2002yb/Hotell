using Model.DAO;
using Model.FE;
using StartHotell.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace StartHotell.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        [HttpGet]
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new UserDao();
            var moder = dao.getListAllPaging(searchString, page, pageSize);
            ViewBag.SeachString = searchString;
            return View(moder);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            var dao = new UserDao();
            var endercode = MD5.GetMD5(user.Password);
            user.Password = endercode;
            long id = dao.Insert(user);
            if (id > 0)
            {
                SetAlert("Thêm user Thành Công", "success");
                ModelState.AddModelError("", "Thêm user Thành Công");
                return RedirectToAction("Index", "User");
            }
            else
            {
                SetAlert("Thêm user Thất Bại", "warning");
                ModelState.AddModelError("", "Thêm user Thất Bại");
            }

            return View("Index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var dao = new UserDao().GetbyID(id);
            return View(dao);
        }
        [HttpPost]
        public ActionResult Update(User user)
        {
            var dao = new UserDao();
            var endercode = MD5.GetMD5(user.Password);
            user.Password = endercode;
            var result = dao.Update(user);
            if (result)
            {
                SetAlert("Sửa user Thành Công", "success");
                ModelState.AddModelError("", "Sửa user Thành Công");
                return RedirectToAction("Index", "User");
            }
            else
            {
                SetAlert("Sửa user Thất Bại", "warning");
                ModelState.AddModelError("", "Sửa user Thất Bại");
            }

            return View("Index");
        }

        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult ChageStatus(long id)
        {
            var result = new UserDao().chagestatus(id);
            return Json(new
            {
                status = result
            });
        }

    }
}