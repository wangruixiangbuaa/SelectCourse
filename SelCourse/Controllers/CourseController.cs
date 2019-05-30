using System;
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
        /// <summary>
        /// 选课页面
        /// 1.获取当前的选课名称，处理下拉列表的信息，获取所有的课程名称
        ///   1.1 查询所有的课程信息，从课程信息里面获取所有的课程名称
        ///   1.2 组成一个list 放入 ViewBag 里面
        /// 2.获取所有的课程信息 
        ///   2.1 查询所有的课程信息从course 表里面，
        ///   2.2 查询所有的选课信息从 selcourse 表里面
        ///   2.3 统计每个课程选课的人数
        /// 3.获取当前学生的姓名
        ///   3.1 从cokie 里面获取到学生的id 
        ///   3.2 根据学生id查询学生数据，获取学生的姓名
        /// 4.返回视图到前台，然后将ViewBag 里面的数据渲染到cshtml 里面
        /// </summary>
        /// <returns></returns>
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


        /// <summary>
        /// 1.获取当前选择的所有课程Id，以及当前学生的编号
        /// 2.根据选择的课程id,生成选课信息。 stuid,courseid  出入后台多少个课程id,就有多少个选课信息
        /// 3.向选课信息表里面添加选课信息。
        ///   3.1 选择数据库中已经有的选课信息
        ///   3.2 校验当前生成的选课信息是否已经存在，存在的话不处理。
        ///   3.3 如果不存在的话，向数据库中插入一条选课信息  stuid ,courseid
        /// 4.执行完之后，返回对应的选课信息返回到前台，进行处理
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectCourseSave()
        {
            SelectionEntities select = new SelectionEntities();
            string cids = Request.QueryString["cids"];
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

