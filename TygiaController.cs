using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanlyNganHang.Models;
using PagedList;

namespace QuanlyNganHang.Controllers
{
    public class TygiaController : Controller
    {
        PMQLNHEntities db = new PMQLNHEntities();
        // GET: Tygia
        public ActionResult Index(int? page)
        {
            if (page == null)
                page = 1;
            var ds = (from tg in db.Tygias select tg).OrderBy(x => x.Manguyente);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(ds.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Edit(string id, string id2)
        {
            Tygia tg = db.Tygias.Find(id, id2);

            return View(tg);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            string ma = f.Get("Manguyente");
            string ma2 = f.Get("Ngayapdunggiamoi");
            Tygia tg = db.Tygias.Find(ma, ma2);
            tg.QuyraVietNamDong = f.Get(("QuyraVietNamDong"));
            tg.Manguyente = f.Get("Manguyente");
            tg.Ngayapdunggiamoi = f.Get("Ngayapdunggiamoi");
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Tygia themtygia)
        {
            PMQLNHEntities db = new PMQLNHEntities();
            db.Tygias.Add(themtygia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id, string id2)
        {
            PMQLNHEntities db = new PMQLNHEntities();
            Tygia mimi = db.Tygias.Find(id, id2);
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
            string Manguyente = f.Get("Manguyente");

            string Ngayapdunggiamoi = f.Get("Ngayapdunggiamoi");

           //var nt = db.Tygias.Find(Manguyente, Ngayapdunggiamoi);
            //cai nao truoc

            return RedirectToAction("details/" + Manguyente + "/" + Ngayapdunggiamoi);

        }
        [HttpGet]

        public ActionResult Delete(string id, string id2)
        {
            PMQLNHEntities db = new PMQLNHEntities();
            Tygia tg = db.Tygias.Find(id, id2);

            return View(tg);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id, string id2)
        {
            PMQLNHEntities db = new PMQLNHEntities();
            Tygia tg = db.Tygias.Find(id, id2);
            db.Tygias.Remove(tg);
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