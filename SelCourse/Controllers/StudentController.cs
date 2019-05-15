using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SelCourse.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            string id = Request.QueryString["courseid"];
            string name = Request.QueryString["stuName"];
            HttpCookie cokie = Request.Cookies.Get("Login");
            ViewBag.CourseId = id;
            ViewBag.StudentName = cokie.Value;
            int cid = 0;
            Int32.TryParse(id, out cid);
            SelectionEntities select = new SelectionEntities();
            Course match = select.Course.Where(r=>r.CourseId == cid).FirstOrDefault();
            if (match != null)
            {
                ViewBag.Course = match.CourseName;
            }
            List<int?> selStus = select.SelCourse.Where(r => r.CourseId == cid).Select(r=>r.StuId).ToList();
            List<StudentInfo> matchStudents =   select.StudentInfo.Where(r=>selStus.Any(sid=> r.StuId == sid)).ToList();
            if (!string.IsNullOrEmpty(name))
            {
                ViewBag.Students = matchStudents.Where(r => r.StuName == name).ToList();
            }
            else
            {
                ViewBag.Students = matchStudents;
            }
            return View("/Views/Student.cshtml");
        }

        public ActionResult Search()
        {
            string stuName = Request.QueryString["stuName"];
            string courseName = Request.QueryString["course"];
            SelectionEntities select = new SelectionEntities();
            ViewBag.Students = select.StudentInfo.Where(r=>r.StuName == stuName).ToList();
            ViewBag.Course = courseName;
            return View("/Views/Student.cshtml");
        }
    }
}