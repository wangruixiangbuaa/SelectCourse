using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace SelCourse.Filters
{
    public class CustomAuthenticationFilter : IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            //如果action 和 controller的添加的特性里面包含匿名的，则直接过滤掉。
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true))
            {
                return;
            }
            var Url = new UrlHelper(filterContext.RequestContext);
            var urlstr = Url.Action("Login","Account");
            //filterContext.Result = new RedirectResult(urlstr); //指定返回重定向登录界面
            HttpCookie cokie = filterContext.HttpContext.Request.Cookies.Get("Login");
            if (cokie == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                                       {
                                           {"controller","Login"},
                                           {"action","Index"},
                                           {"returnUrl",filterContext.HttpContext.Request.RawUrl }
                                       });
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                                       {
                                           {"controller","Account"},
                                           {"action","Login"},
                                           {"returnUrl",filterContext.HttpContext.Request.RawUrl }
                                       });
            }
            //or do something , add challenge to response 

        }
    }
}