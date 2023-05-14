using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanlyNganHang.Models;
using PagedList;

namespace QuanlyNganHang.Controllers
{
    public class HopDongVayController : Controller
    {
       
        PMQLNHEntities db = new PMQLNHEntities();   
        // GET: HopDongVay
        public ActionResult Index(int? page)
        {
            if (page == null)
                page = 1;
            var ds = (from hdv in db.tblHopDongvays select hdv).OrderBy(x => x.Sohopdong);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(ds.ToPagedList(pageNumber, pageSize));
        }
       
        [HttpGet]
        public ActionResult Edit(string id)
        {
            tblHopDongvay  hdv=db.tblHopDongvays.Find(id);
            return View(hdv);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            string ma = f.Get("SoHopDong");
            tblHopDongvay hdv  = db.tblHopDongvays.Find(ma);
            hdv.Ngaylaphopdong = Convert.ToDateTime(f.Get("Ngaylaphopdong"));
            hdv.Machinhanh = f.Get("Machinhanh");
            hdv.Makhachhang = f.Get("Makhachhang");
            hdv.Mathoihan = f.Get("Mathoihan");
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblHopDongvay themhopdong)
        {
            PMQLNHEntities db = new PMQLNHEntities();
            db.tblHopDongvays.Add(themhopdong);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Find()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Find(FormCollection f)
        {
            string Sohopdong = f.Get("Sohopdong");
            var shd = db.tblHopDongvays.Find("Sohopdong");
            return RedirectToAction("details/" + Sohopdong);
        }
        public ActionResult Details(string id)
        {
            PMQLNHEntities db = new PMQLNHEntities();
            tblHopDongvay mimi = db.tblHopDongvays.Find(id);
            return View(mimi);
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            tblHopDongvay hdv = db.tblHopDongvays.Find(id);
            return View(hdv);
        }
        [HttpPost]
        public ActionResult Delete(FormCollection f)
        {
            string sohopdong = f.Get("Sohopdong");
            var cthd = (from t in db.tblHopDongvays where t.Sohopdong == sohopdong select t).FirstOrDefault();
            {
                tblHopDongvay hdv = db.tblHopDongvays.Find(sohopdong);
                db.tblHopDongvays.Remove(hdv);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}