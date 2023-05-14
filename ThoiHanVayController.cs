using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanlyNganHang.Models;
using PagedList;
using System.Web.UI;

namespace QuanlyNganHang.Controllers
{
    public class ThoiHanVayController : Controller
    {
        PMQLNHEntities db = new PMQLNHEntities();
        // GET: ThoiHanVay
        public ActionResult Index(int? page)
        {
            if (page == null)
                page = 1;
            var ds = (from thv in db.tblThoiHanvays select thv).OrderBy(x => x.Mathoihan);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(ds.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            tblThoiHanvay thv = db.tblThoiHanvays.Find(id);

            return View(thv);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            string ma = f.Get("Mathoihan");
            tblThoiHanvay thv = db.tblThoiHanvays.Find(ma);
            thv.Tylelaisuat = f.Get("Tylelaisuat");
            thv.Ghichu = f.Get("Ghichu");
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblThoiHanvay themthoihanvay)
        {
            PMQLNHEntities db = new PMQLNHEntities();
            db.tblThoiHanvays.Add(themthoihanvay);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id)
        {
            PMQLNHEntities db = new PMQLNHEntities();
            tblThoiHanvay mimi = db.tblThoiHanvays.Find(id);
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
            string Mathoihan = f.Get("Mathoihan");
            var thv = db.tblThoiHanvays.Find("Mathoihan");
            return RedirectToAction("details/" + Mathoihan);
        }
        [HttpGet]

        public ActionResult Delete(string id)
        {
            PMQLNHEntities db = new PMQLNHEntities();
            tblThoiHanvay thv = db.tblThoiHanvays.Single(x => x.Mathoihan == id);

            return View(thv);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            PMQLNHEntities db = new PMQLNHEntities();
            tblThoiHanvay thv = db.tblThoiHanvays.Single(x => x.Mathoihan  == id);
            db.tblThoiHanvays.Remove(thv);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}
