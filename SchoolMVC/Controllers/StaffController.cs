using SchoolMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolMVC.Controllers
{
    public class StaffController : Controller
    {
        //staff Member Details 
        SchoolEntityEntities obj_Entity = new SchoolEntityEntities();

        // GET: SchoolClass
        public ActionResult StaffList()
        {
            return View(obj_Entity.Staffs.ToList());
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
        public ActionResult Create(Staff AddStaff)
        {
            if (!ModelState.IsValid)
                return View();
            obj_Entity.Staffs.Add(AddStaff);
            obj_Entity.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("StaffList");


        }

        // GET: SchoolClass/Edit/5
        public ActionResult Edit(int id)
        {
            var StaffToEdit = (from m in obj_Entity.Staffs where m.id == id select m).First();
            return View(StaffToEdit);
        }

        // POST: SchoolClass/Edit/5
        [HttpPost]
        public ActionResult Edit(Staff StaffToEdit)
        {

            var orignalRecord = (from m in obj_Entity.Staffs where m.id == StaffToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            obj_Entity.Entry(orignalRecord).CurrentValues.SetValues(StaffToEdit);

            obj_Entity.SaveChanges();
            return RedirectToAction("StaffList");

        }

        // GET: SchoolClass/Delete/5
        public ActionResult Delete(Staff IdtoDel)
        {

            var d = obj_Entity.Staffs.Where(x => x.id == IdtoDel.id).FirstOrDefault();
            obj_Entity.Staffs.Remove(d);
            obj_Entity.SaveChanges();
            return RedirectToAction("StaffList");
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
