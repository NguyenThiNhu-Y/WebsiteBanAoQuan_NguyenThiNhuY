using ModelEF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var dao = new userDao();
            var model = dao.getAllUser(searchString, page, pagesize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var dao = new userDao();
            dao.Delete(id);
            return RedirectToAction("Index", "User");
        }
    }
}