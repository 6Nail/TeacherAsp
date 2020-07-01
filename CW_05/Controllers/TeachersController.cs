using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CW_05.Data;
using CW_05.Models;
using CW_05.ViewModels;

namespace CW_05.Controllers
{
    public class TeachersController : Controller
    {
        private ApplicationDataContext db = new ApplicationDataContext();

        // GET: Teachers
        public ActionResult Index()
        {
            return View(db.Teachers.ToList());
        }

        // GET: Teachers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // GET: Teachers/Create
        public ActionResult Create()
        {
            ViewBag.Subjects = db.Subjects.ToList();
            return View();
        }

        // POST: Teachers/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeacherViewModel teacherViewModel)
        {
            if (ModelState.IsValid)
            {
                Subject subject = db.Subjects.Find(teacherViewModel.SubjectId);
                Teacher teacher = new Teacher()
                {
                    Name = teacherViewModel.Name,
                    Subject = subject
                };
                db.Teachers.Add(teacher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teacherViewModel);
        }

        // GET: Teachers/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Teacher teacher = db.Teachers.Find(id);
            Teacher teacher = new Teacher();
            teacher = db.Teachers.Find(id);
            TeacherViewModel teacherViewModel = new TeacherViewModel
            {
                Name = teacher.Name,
                SubjectId = teacher.Subject.Id
            };
            if (teacherViewModel == null)
            {
                return HttpNotFound();
            }
            return View(teacherViewModel);
        }

        // POST: Teachers/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TeacherViewModel teacherViewModel)
        {

            if (ModelState.IsValid)
            {
                Subject subject = db.Subjects.Find(teacherViewModel.SubjectId);
                Teacher teacher = new Teacher()
                {
                    Name = teacherViewModel.Name,
                    Subject = subject
                };
                db.Entry(teacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacherViewModel);
        }

        // GET: Teachers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teacher teacher = db.Teachers.Find(id);
            db.Teachers.Remove(teacher);
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
