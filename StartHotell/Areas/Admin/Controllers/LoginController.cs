using Model.DAO;
using StartHotell.Areas.Admin.Model;
using StartHotell.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StartHotell.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, MD5.GetMD5(model.Password));
                if(result == 1)
                {
                    var user = dao.GetByName(model.UserName);
                    var usersession = new UserLogin();
                    usersession.UserName = model.UserName;
                    usersession.UserID = user.ID;
                    Session.Add(Common.CommonConstants.USER_SESSION,usersession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Nhập tài khoản mật khẩu");
                }
                else if(result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản bị khóa");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Sai tài khoản hoặc mật khẩu");
                }
                else
                {
                    ModelState.AddModelError("", "đăng nhập thất bại");
                }
            }
            return View("Index");
        }
    }
}