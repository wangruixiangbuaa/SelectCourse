using MCS.Library.Globalization;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MCS.Library.Core;

namespace System.Web.Mvc
{
    public static class GlobalizationExtensions
    {
        public static MvcHtmlString Translate(this HtmlHelper htmlHelper, string text)
        {
            return Translate(htmlHelper, string.Empty, text);
        }

        public static MvcHtmlString Translate(this HtmlHelper htmlHelper, string category, string text)
        {
            return MvcHtmlString.Create(htmlHelper.TranslateText(category, text));
        }

        public static string TranslateText(this HtmlHelper htmlHelper, string text)
        {
            return TranslateText(htmlHelper, string.Empty, text);
        }

        public static string TranslateText(this HtmlHelper htmlHelper, string category, string text)
        {
            if (category.IsNullOrEmpty())
                category = Path.GetFileName(HttpContext.Current.Request.ApplicationPath);

            return Translator.Translate(category, text);
        }
    }
}