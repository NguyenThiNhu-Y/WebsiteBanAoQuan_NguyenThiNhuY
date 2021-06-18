using ModelEF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Areas.Admin.Models;
using TestUngDung.Common;
namespace TestUngDung.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost] 
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel user)
        {
            if (ModelState.IsValid)
            {
                var dao = new userDao();
                var result = dao.login(user.userName, user.passWord);
                if (result == 1)
                {
                    ModelState.AddModelError("", "Đăng nhập thành công");
                    Session.Add(Constants.USER_SESSION, user);
                    return RedirectToAction("Index", "Home"); //tạo url chuyển hướng đến trang Home
                }
                else
                {
                    if (result == -1)
                    {
                        ModelState.AddModelError("", "Tài khoản của bạn đã bị khóa");
                    }
                    else
                        ModelState.AddModelError("", "Đăng nhập thất bại");
                }
            }
            return View("Index");
        }
    }
}