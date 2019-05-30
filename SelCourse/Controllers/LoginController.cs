using Newtonsoft.Json;
using SelCourse.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SelCourse.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        // GET: Login
        public ActionResult Index()
        {
            return View("/Views/Login.cshtml");
        }

        [HttpPost]
        [AllowAnonymous]
        public  ActionResult DoPostLogin()
        {
            var sr = new StreamReader(Request.InputStream);
            var stream = sr.ReadToEnd();
            var student = JsonConvert.DeserializeObject<StudentInfo>(stream);
            LoginModel model = new LoginModel();
            SelectionEntities selects = new SelectionEntities();
            var match = selects.StudentInfo.Where(r => r.StuName == student.StuName).FirstOrDefault();
            model.Status = "succ";
            model.StuInfo = match;
            JsonResult json = new JsonResult();
            json.Data = model;
            return json;
        }
        /// <summary>
        /// 匿名登录，过滤器不会对 action  或者controller  进行 直接跳过
        /// 1.获取用户名和密码
        /// 2.查询数据库中有没有和用户名和密码匹配的用户
        /// 3.校验查询的数据
        ///   3.1 如果查到用户，则校验成功，跳转成功页面，
        ///   3.2 如果没有找到用户，则校验失败，重新返回到登录页面
        /// 4.校验的数据封装成JSON 返回到前端，前端获取数据，进行提示
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public  ActionResult DoLogin()
        {
            string name = Request.QueryString["username"];
            string pwd = Request.QueryString["password"];
            SelectionEntities selects = new SelectionEntities();
            var match = selects.StudentInfo.Where(r=>r.StuName == name && r.Password == pwd).FirstOrDefault();
            JsonResult jresult = new JsonResult();
            jresult.ContentType = "application/json";
            jresult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            LoginModel model = new LoginModel();
            if (match == null)
            {
                model.Status = "loginFail";
                jresult.Data = model;
                return jresult;
            }
            HttpCookie cokie = new HttpCookie("login");
            cokie.Value = match.StuId.ToString();
            Response.Cookies.Add(cokie);
            if (match.IsAdmin == 1)
            {
                model.StuInfo = match;
                jresult.Data = model;
            }
            else
            {
                model.StuInfo = match;
                jresult.Data = model;
            }
            return jresult;
        }
    }
}