using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanlyNganHang.Models;
using PagedList;

namespace QuanlyNganHang.Controllers
{
    public class KhachhangController : Controller
    {
        PMQLNHEntities db = new PMQLNHEntities();
        // GET: Khachhang
        public ActionResult Index(int? page)
        {

            if (page == null)
                page = 1;
            var ds =( from kh in db.tblKhachhangs select kh).OrderBy(x => x.Makhachhang);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(ds.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            tblKhachhang kh = db.tblKhachhangs.Find(id);
            return View(kh);
        }
        [HttpPost]
        public ActionResult Delete(FormCollection f, tblKhachhang kh)
        {
            string mkh = f.Get("Makhachhang");
            var cthd = (from t in db.tblKhachhangs where t.Makhachhang == mkh select t).FirstOrDefault();
            if (cthd == null)
            {
                tblKhachhang cc = db.tblKhachhangs.Find(mkh);
                db.tblKhachhangs.Remove(cc);
                db.SaveChanges();
            }
            else
            {
                ///khong duoc xoa
                return RedirectToAction("Delete_TB");

            }

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(string id)
        {
            tblKhachhang kh = db.tblKhachhangs.Find(id);
            return View(kh);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f )
        {
            string ma = f.Get("Makhachhang");
            tblKhachhang kh = db.tblKhachhangs.Find(ma);
            kh.Tenkhachhang = f.Get("Tenkhachhang");
            kh.SoCMND = f.Get("soCMND");
            kh.DienThoai = f.Get("DienThoai");
            kh.Diachilienhe = f.Get("Diachilienhe");
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Create()
        { 
          return View(); }
        [HttpPost]
        public ActionResult Create(tblKhachhang themchinhanh)
        {
            PMQLNHEntities db = new PMQLNHEntities();
            db.tblKhachhangs.Add(themchinhanh);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id)
        {
            PMQLNHEntities db = new PMQLNHEntities();
            tblKhachhang mimi = db.tblKhachhangs.Find(id);
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
            string Makhachang = f.Get("Makhachhang");
            var kh = db.tblKhachhangs.Find("Makhachhang");
            return RedirectToAction("details/" + Makhachang);
           
        }
       
    }
}