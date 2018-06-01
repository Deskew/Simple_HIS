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
    public class 诊疗方案信息表Controller : Controller
    {
        private Health_service_DBEntities db = new Health_service_DBEntities();

        // GET: 诊疗方案信息表
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.疾病名称SortParm = String.IsNullOrEmpty(sortOrder) ? "疾病名称_desc" : "";
            ViewBag.典型症状SortParm = sortOrder == "典型症状" ? "典型症状_desc" : "典型症状";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var 诊疗方案信息表s = from s in db.诊疗方案信息表
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                诊疗方案信息表s = 诊疗方案信息表s.Where(s => s.疾病名称.Contains(searchString)
                                       || s.典型症状.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "疾病名称_desc":
                    诊疗方案信息表s = 诊疗方案信息表s.OrderByDescending(s => s.疾病名称);
                    break;
                case "典型症状":
                    诊疗方案信息表s = 诊疗方案信息表s.OrderBy(s => s.典型症状);
                    break;
                case "典型症状_desc":
                    诊疗方案信息表s = 诊疗方案信息表s.OrderByDescending(s => s.典型症状);
                    break;
                default:  // 疾病名称 ascending 
                    诊疗方案信息表s = 诊疗方案信息表s.OrderBy(s => s.疾病名称);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(诊疗方案信息表s.ToPagedList(pageNumber, pageSize));

        }

        // GET: 诊疗方案信息表/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            诊疗方案信息表 诊疗方案信息表 = db.诊疗方案信息表.Find(id);
            if (诊疗方案信息表 == null)
            {
                return HttpNotFound();
            }
            return View(诊疗方案信息表);
        }

        // GET: 诊疗方案信息表/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: 诊疗方案信息表/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "病目编号,疾病名称,典型症状,致病原因,一般治疗手段,治疗周期,治疗大致费用,治疗效果,注意事项")] 诊疗方案信息表 诊疗方案信息表)
        {
            if (ModelState.IsValid)
            {
                db.诊疗方案信息表.Add(诊疗方案信息表);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(诊疗方案信息表);
        }

        // GET: 诊疗方案信息表/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            诊疗方案信息表 诊疗方案信息表 = db.诊疗方案信息表.Find(id);
            if (诊疗方案信息表 == null)
            {
                return HttpNotFound();
            }
            return View(诊疗方案信息表);
        }

        // POST: 诊疗方案信息表/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "病目编号,疾病名称,典型症状,致病原因,一般治疗手段,治疗周期,治疗大致费用,治疗效果,注意事项")] 诊疗方案信息表 诊疗方案信息表)
        {
            if (ModelState.IsValid)
            {
                db.Entry(诊疗方案信息表).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(诊疗方案信息表);
        }

        // GET: 诊疗方案信息表/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            诊疗方案信息表 诊疗方案信息表 = db.诊疗方案信息表.Find(id);
            if (诊疗方案信息表 == null)
            {
                return HttpNotFound();
            }
            return View(诊疗方案信息表);
        }

        // POST: 诊疗方案信息表/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            诊疗方案信息表 诊疗方案信息表 = db.诊疗方案信息表.Find(id);
            db.诊疗方案信息表.Remove(诊疗方案信息表);
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
