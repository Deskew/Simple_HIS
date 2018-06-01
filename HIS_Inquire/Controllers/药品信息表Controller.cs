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
    public class 药品信息表Controller : Controller
    {
        private Health_service_DBEntities db = new Health_service_DBEntities();

        // GET: 药品信息表
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.药品名称SortParm = String.IsNullOrEmpty(sortOrder) ? "药品名称_desc" : "";
            ViewBag.主治症状SortParm = sortOrder == "主治症状" ? "主治症状_desc" : "主治症状";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var 药品信息表s = from s in db.药品信息表
                         select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                药品信息表s = 药品信息表s.Where(s => s.药品名称.Contains(searchString)
                                       || s.主治症状.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "药品名称_desc":
                    药品信息表s = 药品信息表s.OrderByDescending(s => s.药品名称);
                    break;
                case "主治症状":
                    药品信息表s = 药品信息表s.OrderBy(s => s.主治症状);
                    break;
                case "主治症状_desc":
                    药品信息表s = 药品信息表s.OrderByDescending(s => s.主治症状);
                    break;
                default:  // 药品名称 升序
                    药品信息表s = 药品信息表s.OrderBy(s => s.药品名称);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(药品信息表s.ToPagedList(pageNumber, pageSize));

        }

        // GET: 药品信息表/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            药品信息表 药品信息表 = db.药品信息表.Find(id);
            if (药品信息表 == null)
            {
                return HttpNotFound();
            }
            return View(药品信息表);
        }

        // GET: 药品信息表/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: 药品信息表/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "小类编号,药品名称,规格,数量,生产日期,生产厂商,主治症状")] 药品信息表 药品信息表)
        {
            if (ModelState.IsValid)
            {
                db.药品信息表.Add(药品信息表);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(药品信息表);
        }

        // GET: 药品信息表/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            药品信息表 药品信息表 = db.药品信息表.Find(id);
            if (药品信息表 == null)
            {
                return HttpNotFound();
            }
            return View(药品信息表);
        }

        // POST: 药品信息表/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "小类编号,药品名称,规格,数量,生产日期,生产厂商,主治症状")] 药品信息表 药品信息表)
        {
            if (ModelState.IsValid)
            {
                db.Entry(药品信息表).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(药品信息表);
        }

        // GET: 药品信息表/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            药品信息表 药品信息表 = db.药品信息表.Find(id);
            if (药品信息表 == null)
            {
                return HttpNotFound();
            }
            return View(药品信息表);
        }

        // POST: 药品信息表/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            药品信息表 药品信息表 = db.药品信息表.Find(id);
            db.药品信息表.Remove(药品信息表);
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
