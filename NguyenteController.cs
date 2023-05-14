using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanlyNganHang.Models;
using PagedList;
using System.Drawing.Printing;

namespace QuanlyNganHang.Controllers
{
    public class NguyenteController : Controller
    { PMQLNHEntities db =new PMQLNHEntities();  
        // GET: Nguyente
        public ActionResult Index(int? page)
        {
            if (page == null)
                page = 1;
            var ds =  (from nt in db.tblNguyentes select nt).OrderBy(x => x.Manguyente);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(ds.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            tblNguyente nt = db.tblNguyentes.Find(id);

            return View(nt);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            string ma = f.Get("Manguyente");
            tblNguyente nt = db.tblNguyentes.Find(ma);
            nt.Tennguyente = f.Get("Tennguyente");
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblNguyente themnguyente)
        {
            PMQLNHEntities db = new PMQLNHEntities();
            db.tblNguyentes.Add(themnguyente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id)
        {
            PMQLNHEntities db = new PMQLNHEntities();
            tblNguyente mimi = db.tblNguyentes.Find(id);
            return View(mimi);
        }
        [HttpGet]
        public ActionResult Find()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Find(FormCollection f)
        {
            string manguyente = f.Get("Manguyente");
            var kh = db.tblNguyentes.Find("Manguyente");
            return RedirectToAction("details/" + manguyente);

        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            tblNguyente nt = db.tblNguyentes.Find(id);
            return View(nt);
        }
        [HttpPost]
        public ActionResult Delete(FormCollection f)
        {
            string Manguyente = f.Get("Manguyente");
            var cthd = (from t in db.tblNguyentes where t.Manguyente == Manguyente select t).FirstOrDefault();
            {
                tblNguyente nt = db.tblNguyentes.Find(Manguyente);
                db.tblNguyentes.Remove(nt);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}