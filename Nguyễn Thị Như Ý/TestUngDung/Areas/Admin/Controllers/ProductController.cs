using ModelEF;
using ModelEF.DAO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index()
        {
            var dao = new productDao();
            var model = dao.GetAllProducts();
            return View(model);
        }
        public ActionResult Details(string id)
        {
            var dao = new productDao();
            var model = dao.Detail(id);
            return View(model);
        }
        public void setViewBag(string i = null)
        {
            var dao = new categoryDao();
            var listLoai = dao.getAllCategory("");
            ViewBag.tenLoai = new SelectList(listLoai, "id", "name", i);
        }
        public string newID()
        {
            string id;
            var db = new NguyenThiNhuYContext();
            string sql = db.Database.SqlQuery<string>("select max(right(ID, 3)) from tblProduct").FirstOrDefault();
            id = "00000" + (int.Parse(sql) + 1);
            id = "SP" + id.Substring(id.Length - 3);
            return id;
        }
        [HttpGet]
        public ActionResult Create()
        {
            setViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblProduct pr, HttpPostedFileBase file)
        {
            var dao = new productDao();
            var db = new NguyenThiNhuYContext();
            if (ModelState.IsValid)
            {
                setViewBag();
                pr.ID = newID();
                pr.Status = "c";
                dao.Insert(pr);
                string returnImagePath = string.Empty;
                if (file != null && file.ContentLength > 0)
                {
                    string fileName, fileExtension, imaageSavePath, name;
                    fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    fileExtension = Path.GetExtension(file.FileName);

                    imaageSavePath = Server.MapPath("~/uploadedImages/") + fileName + fileExtension;
                    //Save file
                    file.SaveAs(imaageSavePath);
                    name = fileName + fileExtension;
                    tblProduct p = db.tblProducts.FirstOrDefault(x => x.ID == pr.ID);
                    p.image = name;
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Product");
            }
            setViewBag();
            return View();
        }

    }
}