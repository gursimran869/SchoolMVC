using SchoolMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolMVC.Controllers
{
    public class SchoolClassController : Controller
    {

        SchoolEntityEntities obj_Entity = new SchoolEntityEntities();

        // GET: SchoolClass
        public ActionResult classList()
        {
            return View(obj_Entity.Classes.ToList());
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
        public ActionResult Create(Class AddClass)
        {
            if (!ModelState.IsValid)
                return View();
            obj_Entity.Classes.Add(AddClass);
            obj_Entity.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("classList");


        }

        // GET: SchoolClass/Edit/5
        public ActionResult Edit(int id)
        {
            var classToEdit = (from m in obj_Entity.Classes where m.id == id select m).First();
            return View(classToEdit);
        }

        // POST: SchoolClass/Edit/5
        [HttpPost]
        public ActionResult Edit(Class classToEdit)
        {

            var orignalRecord = (from m in obj_Entity.Classes where m.id == classToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            obj_Entity.Entry(orignalRecord).CurrentValues.SetValues(classToEdit);

            obj_Entity.SaveChanges();
            return RedirectToAction("classList");

        }

        // GET: SchoolClass/Delete/5
        public ActionResult Delete(Class IdtoDel)
        {

            var d = obj_Entity.Classes.Where(x => x.id == IdtoDel.id).FirstOrDefault();
            obj_Entity.Classes.Remove(d);
            obj_Entity.SaveChanges();
            return RedirectToAction("classList");
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
