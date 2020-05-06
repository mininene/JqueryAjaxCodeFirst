using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AjaxCrudOperationUsingMVC5.DAL;
using AjaxCrudOperationUsingMVC5.Models;

namespace AjaxCrudOperationUsingMVC5.Controllers
{
    public class UsersController : Controller
    {
        private UsersContext db = new UsersContext();

        // GET: Users

        public ActionResult Index()
        {
            return View();
        }


         public JsonResult List()
        {
            return Json(db.Users.ToList(), JsonRequestBehavior.AllowGet);
        }


        //// GET: Users/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Users users = db.Users.Find(id);
        //    if (users == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(users);
        //}

     

        public JsonResult Create([Bind(Include = "Id,Name,Age,State,Country")] Users users)
        {
                db.Users.Add(users);
                db.SaveChanges();
            
            return Json(JsonRequestBehavior.AllowGet);
        }



        public JsonResult GetById(int id)
        {

            Users users = db.Users.Find(id);
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        

        public JsonResult Edit([Bind(Include = "Id,Name,Age,State,Country")] Users users)
        {
            db.Entry(users).State = EntityState.Modified;
            db.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int Id)
        {
            Users users = db.Users.Find(Id);
            db.Users.Remove(users);
            db.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
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
