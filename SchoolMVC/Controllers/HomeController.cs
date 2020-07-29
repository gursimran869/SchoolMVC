using SchoolMVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolMVC.Controllers
{
    public class HomeController : Controller
    {
        Connection obj_Feed = new Connection();
        SchoolEntityEntities obj_Entity = new SchoolEntityEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        public ActionResult Login()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult LoginDetails(Admin_Login log)
        {


            String query = "select * from Admin where AdminID='" + log.Name + "' and AdminPassword='" + log.Password + "'";
            DataTable tbl = new DataTable();
            tbl = obj_Feed.SrchLogin(query);

            if (tbl.Rows.Count > 0)
            {
                return View("AdminPannel");
            }
            else
            {
                return View("WrongPassword");
            }

        }
        public ActionResult AdminPannel()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult WrongPassword()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        

        public ActionResult AllMessage()
        {
            

            return View(obj_Entity.Messages.ToList());
        }

        // GET: Order/Delete/5
        public ActionResult Delete(Message IdToDelete)
        {

            var d = obj_Entity.Messages.Where(x => x.id == IdToDelete.id).FirstOrDefault();
            obj_Entity.Messages.Remove(d);
            obj_Entity.SaveChanges();
            return RedirectToAction("AllMessage");
        }



        [HttpPost]
        public ActionResult SubmitMessage(VisitorQuery log)
        {

            //create the object of the class to pass the value to the database by using the insert query 
            
            
            String query = "insert into Message(Name,Email,Contact,Message) values('" + log.txtName + "','" + log.txtEmail + "','" + log.txtContact + "','" + log.txtMsg + "')";
            
            obj_Feed.sendfeedback(query);
            
            return View("FeedBack");


        }


        public ActionResult FeedBack()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}