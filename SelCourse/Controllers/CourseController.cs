﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
/// <summary>
/// https://docs.microsoft.com/zh-cn/dotnet/
/// </summary>
namespace SelCourse.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            SelectionEntities select = new SelectionEntities();
            string courseType = Request.QueryString["type"];
            string pageIndex = Request.QueryString["pageIndex"];
            string pageSize = Request.QueryString["pageSize"];
            WrapPageData<Course> pageCourses = new WrapPageData<Course>();
            int index = 0;
            int size = 3;
            int.TryParse(pageIndex,out index);
            int.TryParse(pageSize, out size);
            size = size == 0 ? 3 : size;
            index = index > 0 ? index - 1 : 0;
            ViewBag.CourseTypes = GetCourseType();
            List<SelCourse> sels = select.SelCourse.ToList();
            if (string.IsNullOrEmpty(courseType))
            {
                pageCourses.Data = select.Course.OrderBy(r => r.CourseId).Skip(index * size).Take(size).ToList();
                pageCourses.totalCount = select.Course.Count();
            }
            else
            {
                pageCourses.Data = select.Course.Where(r=>r.CourseType == courseType).OrderBy(r => r.CourseId).Skip(index * size).Take(size).ToList();
                pageCourses.totalCount = select.Course.Where(r=>r.CourseType == courseType).Count();
            }
            foreach (Course course in pageCourses.Data)
            {
                int selNum = sels.Where(r => r.CourseId == course.CourseId).Count();
                course.CourseSel = course.CourseTotal - selNum;
            }
            ViewBag.CurrentType = courseType;
            ViewBag.Courses = pageCourses.Data;
            ViewBag.Pages = pageCourses.GetPages(index, size, pageCourses.totalCount);
            ViewBag.PageSize = 3;
            return View("/Views/Course/Index.cshtml");
        }

        public List<GeneralSelectItem> GetCourseType()
        {
            SelectionEntities select = new SelectionEntities();
            List<GeneralSelectItem> courseTypes = new List<GeneralSelectItem>();
            courseTypes.Add(new GeneralSelectItem() { Text = "请选择", Value = "" });
            courseTypes.AddRange(select.Course.Select(r => new GeneralSelectItem()
                                                          { Text = r.CourseType, Value = r.CourseType }
                                                     ).Distinct());
            return courseTypes;
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
            int result = select.SaveChanges();
            ViewBag.Courses = select.Course.ToList();
            ViewBag.CourseTypes = GetCourseType();
            JsonResult jsonData = new JsonResult();
            jsonData.Data = course;
            jsonData.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return jsonData;
        }

        public ActionResult DeleteCourse(int aid)
        {
            string id = Request.QueryString["id"];
            int did = 0;
            Int32.TryParse(id,out did);
            SelectionEntities select = new SelectionEntities();
            Course course = select.Course.Where(r => r.CourseId == did).FirstOrDefault();
            JsonResult jsonData = new JsonResult();
            if (course == null)
            {
                jsonData.Data = "课程已经删除！";
                return jsonData;
            }
            select.Course.Remove(course);
            select.SaveChanges();
            ViewBag.Courses = select.Course.ToList();
            ViewBag.CourseTypes = GetCourseType();
            jsonData.Data = course;
            jsonData.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return jsonData;
        }

        public ActionResult ADeleteCourse(string id)
        {
            int did = 0;
            Int32.TryParse(id, out did);
            SelectionEntities select = new SelectionEntities();
            Course course = select.Course.Where(r => r.CourseId == did).FirstOrDefault();
            JsonResult jsonData = new JsonResult();
            if (course == null)
            {
                jsonData.Data = "课程已经删除！";
                return jsonData;
            }
            select.Course.Remove(course);
            select.SaveChanges();
            ViewBag.Courses = select.Course.ToList();
            ViewBag.CourseTypes = GetCourseType();
            jsonData.Data = course;
            jsonData.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return jsonData;
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
            select.Entry<Course>(course).State = System.Data.EntityState.Modified;
            //select.Course.Add(course);
            select.SaveChanges();
            ViewBag.Courses = select.Course.ToList();
            ViewBag.CourseTypes = GetCourseType();
            return View("/Views/Course/Index.cshtml");
        }

        public List<GeneralSelectItem> GetAllCourseNames()
        {
            SelectionEntities select = new SelectionEntities();
            List<GeneralSelectItem> courseTypes = new List<GeneralSelectItem>();
            courseTypes.Add(new GeneralSelectItem() { Text = "请选择", Value = "" });
            courseTypes.AddRange(select.Course.Select(r => new GeneralSelectItem() { Text = r.CourseName, Value = r.CourseName }).Distinct());
            return courseTypes;
        }

        public ActionResult SelectCourse()
        {
            string courseName = Request.QueryString["courseName"];
            SelectionEntities select = new SelectionEntities();
            ViewBag.CourseNames = GetAllCourseNames();
            List<SelCourse> sels = select.SelCourse.ToList();
            List<Course> courses = select.Course.ToList();

            foreach (Course course in courses)
            {
                int selNum = sels.Where(r => r.CourseId == course.CourseId).Count();
                course.CourseSel = course.CourseTotal - selNum;
            }

            if (!string.IsNullOrEmpty(courseName))
            {
                ViewBag.Courses = select.Course.Where(r=>r.CourseName == courseName).ToList();
            }
            else
            {
                ViewBag.Courses = select.Course.ToList();
            }
           
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
            ViewBag.CourseNames = GetAllCourseNames();
            HttpCookie cokie = Request.Cookies.Get("Login");
            JsonResult json = new JsonResult();
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
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
            string errString = "";
            foreach (var item in cidarray)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    maxid = maxid++;
                    int cid = Convert.ToInt32(item);
                    var match = select.SelCourse.Where(r => r.CourseId == cid && r.StuId == stuId).FirstOrDefault();
                    if (match == null)
                    {
                        SelCourse sel = new SelCourse();
                        sel.StuId = stuId;
                        sel.CourseId = cid;
                        sel.SelId = maxid + 1;
                        select.SelCourse.Add(sel);
                        select.SaveChanges();
                    }
                    else
                    {
                        var course = select.Course.Where(r => r.CourseId == cid).FirstOrDefault();
                        errString += string.Format("已经选过{0},课程",course.CourseName);
                    }
                }
            }
            json.Data = errString;
            return json;
        }

    }
}

