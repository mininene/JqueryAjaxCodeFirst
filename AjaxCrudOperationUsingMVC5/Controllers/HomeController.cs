using AjaxCrudOperationUsingMVC5.DAL;
using AjaxCrudOperationUsingMVC5.Models;
using System.Linq;
using System.Web.Mvc;

namespace AjaxCrudOperationUsingMVC5.Controllers
{
    public class HomeController : Controller
    {
        private UsersContext _context;
        public HomeController()
        {
            _context = new UsersContext();
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            return Json(_context.Users.ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            return Json(_context.Users.FirstOrDefault(x=>x.Id==ID), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(Users user)
        {
            var data = _context.Users.FirstOrDefault(x => x.Id == user.Id);
            if (data != null) {
                data.Name = user.Name;
                data.State = user.State;
                data.Country = user.Country;
                data.Age = user.Age;
                _context.SaveChanges();
            }
            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            var data = _context.Users.FirstOrDefault(x => x.Id == ID);
            _context.Users.Remove(data);
            _context.SaveChanges();
            return Json(JsonRequestBehavior.AllowGet);


        }
    }
}