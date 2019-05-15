using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SelCourse.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            SelectionEntities select = new SelectionEntities();
            string courseType = Request.QueryString["type"];
            List<GeneralSelectItem> courseTypes = new List<GeneralSelectItem>();
            courseTypes.Add(new GeneralSelectItem() { Text = "请选择", Value = "" });
            courseTypes.AddRange(select.Course.Select(r => new GeneralSelectItem() { Text = r.CourseType, Value = r.CourseType }).Distinct());
            ViewBag.CourseTypes = courseTypes;
            List<SelCourse> sels = select.SelCourse.ToList();
            List<Course> courses = select.Course.ToList();
            foreach (Course course in courses)
            {
                int selNum = sels.Where(r => r.CourseId == course.CourseId).Count();
                course.CourseSel = course.CourseTotal - selNum;
            }
            ViewBag.CurrentType = courseType;
            if (string.IsNullOrEmpty(courseType))
            {
                ViewBag.Courses = courses;
            }else
            {
                ViewBag.Courses = courses.Where(r => r.CourseType == courseType).ToList();
            }
            
            return View("/Views/Course/Index.cshtml");
        }

        public ActionResult AddCourse()
        {
            string name = Request.QueryString["name"];
            string des = Request.QueryString["des"];
            string type = Request.QueryString["type"];
            string num = Request.QueryString["num"];
            SelectionEntities select = new SelectionEntities();
            int newid = 0;
            if (select.Course.Count() > 0)
            {
                newid = select.Course.Max(r => r.CourseId) + 1;
            }
            Course course = new Course();
            course.CourseId = newid;
            course.CourseName = name;
            course.CourseRemark = des;
            course.CourseType = type;
            course.CourseTotal = Convert.ToInt32(num);
            select.Course.Add(course);
            select.SaveChanges();
            ViewBag.Courses = select.Course.ToList();
            ViewBag.CourseTypes = select.Course.Select(r => r.CourseType).Distinct();
            return View("/Views/Course/Index.cshtml");
        }

        public ActionResult DeleteCourse()
        {
            string id = Request.QueryString["id"];
            int did = 0;
            Int32.TryParse(id,out did);
            SelectionEntities select = new SelectionEntities();
            Course course = select.Course.Where(r => r.CourseId == did).FirstOrDefault();
            if (course == null)
            {
                return View("/Views/Course/Index.cshtml");
            }
            select.Course.Remove(course);
            select.SaveChanges();
            ViewBag.Courses = select.Course.ToList();
            ViewBag.CourseTypes = select.Course.Select(r => r.CourseType).Distinct();
            return View("/Views/Course/Index.cshtml");
        }

        public ActionResult UpdateCourse()
        {
            string id = Request.QueryString["id"];
            string name = Request.QueryString["name"];
            string des = Request.QueryString["des"];
            string type = Request.QueryString["type"];
            string num = Request.QueryString["num"];
            int did = 0;
            Int32.TryParse(id, out did);
            SelectionEntities select = new SelectionEntities();
            Course course = select.Course.Where(r => r.CourseId == did).FirstOrDefault();
            course.CourseId = Convert.ToInt32(id);
            course.CourseName = name;
            course.CourseRemark = des;
            course.CourseType = type;
            course.CourseTotal = Convert.ToInt32(num);
            if (course == null)
            {
                return View("/Views/Course/Index.cshtml");
            }

            //select.Course.Add(course);
            select.SaveChanges();
            ViewBag.Courses = select.Course.ToList();
            ViewBag.CourseTypes = select.Course.Select(r => r.CourseType).Distinct();
            return View("/Views/Course/Index.cshtml");
        }

        public ActionResult SelectCourse()
        {
            SelectionEntities select = new SelectionEntities();
            List<SelCourse> sels = select.SelCourse.ToList();
            List<Course> courses = select.Course.ToList();
            foreach (Course course in courses)
            {
                int selNum = sels.Where(r => r.CourseId == course.CourseId).Count();
                course.CourseSel = course.CourseTotal - selNum;
            }
            ViewBag.Courses = select.Course.ToList();
            HttpCookie cokie = Request.Cookies.Get("Login");
            if (cokie != null)
            {
                int id = Convert.ToInt32(cokie.Value);
                StudentInfo stu = select.StudentInfo.Where(r => r.StuId == id ).FirstOrDefault();

                ViewBag.StudentName = stu == null ? "" : stu.StuName;
            }
            return View("/Views/Select.cshtml");
        }

        

        public ActionResult SelectCourseSave()
        {
            SelectionEntities select = new SelectionEntities();
            string cids = Request.QueryString["cids"];
            ViewBag.Courses = select.Course.ToList();
            HttpCookie cokie = Request.Cookies.Get("Login");
            int stuId = 0;
            if (cokie != null)
            {
                stuId = Convert.ToInt32(cokie.Value);
            }
            string[] cidarray = cids.Split(',');

            int maxid = 0;
            if (select.SelCourse.Count() > 0)
            {
                maxid = select.SelCourse.Count();
            };
            foreach (var item in cidarray)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    int cid = Convert.ToInt32(item);
                    SelCourse sel = new SelCourse();
                    sel.StuId = stuId;
                    sel.CourseId = cid;
                    sel.SelId = maxid + 1;
                    select.SelCourse.Add(sel);
                    
                    select.SaveChanges();
                }
            }

            return View("/Views/Select.cshtml");
        }

    }
}

