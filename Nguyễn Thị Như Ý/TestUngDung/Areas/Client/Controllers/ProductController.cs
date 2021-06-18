using ModelEF.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Client.Controllers
{
    public class ProductController : Controller
    {
        // GET: Client/Product
        public ActionResult Index()
        {
            var dao = new productDao();
            var model = dao.GetAllProducts();
            return View(model);
        }

    }
}