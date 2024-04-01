using Model.DAO;
using Model.FE;
using StartHotell.Common;
using StartHotell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StartHotell.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, MD5.GetMD5(model.Password));
                if (result == 1)
                {
                    var user = dao.GetByName(model.UserName);
                    var usersession = new UserLogin();
                    usersession.UserName = model.UserName;
                    usersession.UserID = user.ID;
                    Session.Add(Common.CommonConstants.USER_SESSION, usersession);
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return Redirect("/");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Nhập tài khoản mật khẩu");
                }
                else if (result == -1)
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
            return View("Login");
        }
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                if (dao.Checkusername(model.UserName))
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else if (dao.Checkemail(model.Email))
                {
                    ModelState.AddModelError("", "Email đã tồn tại");
                }
                else
                {
                    var user = new User();
                    var endercode = MD5.GetMD5(model.Password);
                    user.UserName = model.UserName;
                    user.Password = endercode;
                    user.Name = model.Name;
                    user.Address = model.Address;
                    user.Email = model.Email;
                    user.Phone = model.Phone;
                    user.CreatedDate = DateTime.Now;
                    user.Status = true;
                    var result = dao.Insert(user);
                    if (result > 0)
                    {
                        ViewBag.Success = "Đăng ký Thành công";
                        model = new RegisterModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký thất bại");
                    }
                }
            }
            return View(model);
        }
        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return Redirect("/");
        }
    }
}