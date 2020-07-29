using SchoolMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolMVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        SchoolEntityEntities obj_Entity = new SchoolEntityEntities();

        // GET: SchoolClass
        public ActionResult StudentList()
        {
            return View(obj_Entity.Students.ToList());
        }

        // GET: SchoolClass/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SchoolClass/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchoolClass/Create
        [HttpPost]
        public ActionResult Create(Student AddStudent)
        {
            if (!ModelState.IsValid)
                return View();
            obj_Entity.Students.Add(AddStudent);
            obj_Entity.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("studentList");


        }

        // GET: SchoolClass/Edit/5
        public ActionResult Edit(int id)
        {
            var StudentToEdit = (from m in obj_Entity.Students where m.id == id select m).First();
            return View(StudentToEdit);
        }

        // POST: SchoolClass/Edit/5
        [HttpPost]
        public ActionResult Edit(Student StudentToEdit)
        {

            var orignalRecord = (from m in obj_Entity.Students where m.id == StudentToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            obj_Entity.Entry(orignalRecord).CurrentValues.SetValues(StudentToEdit);

            obj_Entity.SaveChanges();
            return RedirectToAction("StudentList");

        }

        // GET: SchoolClass/Delete/5
        public ActionResult Delete(Student IdtoDel)
        {

            var d = obj_Entity.Students.Where(x => x.id == IdtoDel.id).FirstOrDefault();
            obj_Entity.Students.Remove(d);
            obj_Entity.SaveChanges();
            return RedirectToAction("StudentList");
        }

        // POST: SchoolClass/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
