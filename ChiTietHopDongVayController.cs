using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using QuanlyNganHang.Models;
using PagedList;

namespace QuanlyNganHang.Controllers
{
    public class ChiTietHopDongVayController : Controller
    {
        PMQLNHEntities db = new PMQLNHEntities();
        // GET: ChiTietHopDongVay
        public ActionResult Index(int? page)
        {

            if (page == null)
                page = 1;
            var ds =( from cthdv in db.tblChiTiethopdongvays select cthdv).OrderBy(x => x.Sohopdong);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(ds.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Edit(string id, string id2)
        {
            tblChiTiethopdongvay cthdv = db.tblChiTiethopdongvays.Find(id, id2);

            return View(cthdv);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            string ma = f.Get("SoHopDong");
            string ma2 = f.Get("Manguyente");
            tblChiTiethopdongvay cthdv = db.tblChiTiethopdongvays.Find(ma, ma2);
            cthdv.Manguyente = f.Get("Manguyente");
            cthdv.Sohopdong = f.Get("Sohopdong");
            cthdv.Soluong = f.Get("Soluong");
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblChiTiethopdongvay themhopdong)
        {
            PMQLNHEntities db = new PMQLNHEntities();
            db.tblChiTiethopdongvays.Add(themhopdong);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id, string id2)
        {
            PMQLNHEntities db = new PMQLNHEntities();
            tblChiTiethopdongvay mimi = db.tblChiTiethopdongvays.Find(id, id2);
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
            string sohopdong = f.Get("Sohopdong");
            string manguyente = f.Get("Manguyente");
            //var nt = db.tblChiTiethopdongvays.Find(sohopdong, manguyente);
            // cai nao truoc
            return RedirectToAction("details/" + sohopdong + "/" + manguyente);

        }
        [HttpGet]

        public ActionResult Delete(string id, string id2)
        {
            PMQLNHEntities db = new PMQLNHEntities();
            tblChiTiethopdongvay cthdv = db.tblChiTiethopdongvays.Find(id, id2);

            return View(cthdv);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id, string id2)
        {
            PMQLNHEntities db = new PMQLNHEntities();
            tblChiTiethopdongvay cthvd = db.tblChiTiethopdongvays.Find(id, id2);
            db.tblChiTiethopdongvays.Remove(cthvd);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}