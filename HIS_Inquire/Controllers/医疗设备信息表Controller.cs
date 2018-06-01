using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using PagedList;

using HIS_Inquire.Models;

namespace HIS_Inquire.Controllers
{
    public class 医疗设备信息表Controller : Controller
    {
        private Health_service_DBEntities db = new Health_service_DBEntities();

        // GET: 医疗设备信息表
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.设备名称SortParm = String.IsNullOrEmpty(sortOrder) ? "设备名称_desc" : "";
            ViewBag.所属科室SortParm = sortOrder == "所属科室" ? "所属科室_desc" : "所属科室";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var 医疗设备信息表s = from s in db.医疗设备信息表
                         select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                医疗设备信息表s = 医疗设备信息表s.Where(s => s.设备名称.Contains(searchString)
                                       || s.所属科室.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "设备名称_desc":
                    医疗设备信息表s = 医疗设备信息表s.OrderByDescending(s => s.设备名称);
                    break;
                case "所属科室":
                    医疗设备信息表s = 医疗设备信息表s.OrderBy(s => s.所属科室);
                    break;
                case "所属科室_desc":
                    医疗设备信息表s = 医疗设备信息表s.OrderByDescending(s => s.所属科室);
                    break;
                default:  // 药品名称 升序
                    医疗设备信息表s = 医疗设备信息表s.OrderBy(s => s.设备名称);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(医疗设备信息表s.ToPagedList(pageNumber, pageSize));

        }

        // GET: 医疗设备信息表/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            医疗设备信息表 医疗设备信息表 = db.医疗设备信息表.Find(id);
            if (医疗设备信息表 == null)
            {
                return HttpNotFound();
            }
            return View(医疗设备信息表);
        }

        // GET: 医疗设备信息表/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: 医疗设备信息表/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "注册编号,设备名称,规格,所属科室,生产日期,生产厂商,维修记录,维修负责人")] 医疗设备信息表 医疗设备信息表)
        {
            if (ModelState.IsValid)
            {
                db.医疗设备信息表.Add(医疗设备信息表);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(医疗设备信息表);
        }

        // GET: 医疗设备信息表/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            医疗设备信息表 医疗设备信息表 = db.医疗设备信息表.Find(id);
            if (医疗设备信息表 == null)
            {
                return HttpNotFound();
            }
            return View(医疗设备信息表);
        }

        // POST: 医疗设备信息表/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "注册编号,设备名称,规格,所属科室,生产日期,生产厂商,维修记录,维修负责人")] 医疗设备信息表 医疗设备信息表)
        {
            if (ModelState.IsValid)
            {
                db.Entry(医疗设备信息表).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(医疗设备信息表);
        }

        // GET: 医疗设备信息表/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            医疗设备信息表 医疗设备信息表 = db.医疗设备信息表.Find(id);
            if (医疗设备信息表 == null)
            {
                return HttpNotFound();
            }
            return View(医疗设备信息表);
        }

        // POST: 医疗设备信息表/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            医疗设备信息表 医疗设备信息表 = db.医疗设备信息表.Find(id);
            db.医疗设备信息表.Remove(医疗设备信息表);
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
