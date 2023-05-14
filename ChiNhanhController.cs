using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanlyNganHang.Models;
using PagedList;
namespace QuanlyNganHang.Controllers
{
    public class ChiNhanhController : Controller
    {
        PMQLNHEntities db = new PMQLNHEntities();
        // GET: ChiNhanh
        public ActionResult Index(int? page)
        {
            if(page == null)
                page = 1;
            var ds = (from cn in db.tblChiNhanhs select cn).OrderBy(x=>x.Machinhanh);
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(ds.ToPagedList(pageNumber,pageSize));
        }
        [HttpGet]

       public ActionResult Delete(string id)
        {
           PMQLNHEntities db= new PMQLNHEntities();
            tblChiNhanh cn = db.tblChiNhanhs.Single(x => x.Machinhanh == id);
            
                  return View(cn);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            PMQLNHEntities db = new PMQLNHEntities();
            tblChiNhanh cn = db.tblChiNhanhs.Single(x => x.Machinhanh == id);
            db.tblChiNhanhs.Remove(cn);
            db.SaveChanges();   
            return RedirectToAction("Index");   
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            tblChiNhanh cn = db.tblChiNhanhs.Find(id);
            
            return View(cn);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection f)
        {
            string ma = f.Get("Machinhanh");
            tblChiNhanh cn = db.tblChiNhanhs.Find(ma);
            cn.TenChiNhanh = f.Get("TenChiNhanh");
            cn.DiaChi = f.Get("DiaChi");
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return   View();    
        }
        [HttpPost]
        public ActionResult Create(tblChiNhanh themchinhanh)
        {
            PMQLNHEntities  db = new PMQLNHEntities();
            db.tblChiNhanhs.Add(themchinhanh); 
            db.SaveChanges();   
            return RedirectToAction("Index");   
        }
            public ActionResult Details(string id)
            {
                PMQLNHEntities db = new PMQLNHEntities();
                tblChiNhanh mimi = db.tblChiNhanhs.Find(id);
                return View(mimi);
            }
        [HttpGet]
        public ActionResult Find( )
        {
            return View();
        }
        [HttpPost]
        public  ActionResult Find (FormCollection f)
        {
            string Machinhanh = f.Get("Machinhanh");
            var cn = db.tblChiNhanhs.Find("Machinhanh");
            return RedirectToAction("details/"+Machinhanh);
        }

    }
}