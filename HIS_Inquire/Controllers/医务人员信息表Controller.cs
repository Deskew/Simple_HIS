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
    public class 医务人员信息表Controller : Controller
    {
        private Health_service_DBEntities db = new Health_service_DBEntities();

        // GET: 医务人员信息表
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.姓名SortParm = String.IsNullOrEmpty(sortOrder) ? "姓名_desc" : "";
            ViewBag.专业职务SortParm = sortOrder == "专业职务" ? "专业职务_desc" : "专业职务";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var 医务人员信息表s = from s in db.医务人员信息表
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                医务人员信息表s = 医务人员信息表s.Where(s => s.姓名.Contains(searchString)
                                       || s.专业职务.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "姓名_desc":
                    医务人员信息表s = 医务人员信息表s.OrderByDescending(s => s.姓名);
                    break;
                case "专业职务":
                    医务人员信息表s = 医务人员信息表s.OrderBy(s => s.所属科室);
                    break;
                case "专业职务_desc":
                    医务人员信息表s = 医务人员信息表s.OrderByDescending(s => s.专业职务);
                    break;
                default:  // 药品名称 升序
                    医务人员信息表s = 医务人员信息表s.OrderBy(s => s.姓名);
                    break;
            }

            int pageSize = 3; //设置每页的数据量
            int pageNumber = (page ?? 1);
            return View(医务人员信息表s.ToPagedList(pageNumber, pageSize));

        }

        // GET: 医务人员信息表/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            医务人员信息表 医务人员信息表 = db.医务人员信息表.Find(id);
            if (医务人员信息表 == null)
            {
                return HttpNotFound();
            }
            return View(医务人员信息表);
        }

        // GET: 医务人员信息表/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: 医务人员信息表/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "编号,姓名,性别,所属科室,专业职务,学历,出生日期,名族,政治面貌,从医经历,婚姻状况,科室电话")] 医务人员信息表 医务人员信息表)
        {
            if (ModelState.IsValid)
            {
                db.医务人员信息表.Add(医务人员信息表);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(医务人员信息表);
        }

        // GET: 医务人员信息表/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            医务人员信息表 医务人员信息表 = db.医务人员信息表.Find(id);
            if (医务人员信息表 == null)
            {
                return HttpNotFound();
            }
            return View(医务人员信息表);
        }

        // POST: 医务人员信息表/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "编号,姓名,性别,所属科室,专业职务,学历,出生日期,名族,政治面貌,从医经历,婚姻状况,科室电话")] 医务人员信息表 医务人员信息表)
        {
            if (ModelState.IsValid)
            {
                db.Entry(医务人员信息表).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(医务人员信息表);
        }

        // GET: 医务人员信息表/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            医务人员信息表 医务人员信息表 = db.医务人员信息表.Find(id);
            if (医务人员信息表 == null)
            {
                return HttpNotFound();
            }
            return View(医务人员信息表);
        }

        // POST: 医务人员信息表/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            医务人员信息表 医务人员信息表 = db.医务人员信息表.Find(id);
            db.医务人员信息表.Remove(医务人员信息表);
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
