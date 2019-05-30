using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelCourse
{
    public class WrapPageData<T>  where T:class
    {
        public int pageIndex { get; set; }

        public int pageSize { get; set; }

        public int totalCount { get; set; }

        public int totalPages { get; set;}

        public int currentPageIndex { get; set; }

        public List<T> Data { get; set; }

        /// <summary>
        /// 分页相关逻辑内容
        /// </summary>
        /// <param name="index"></param>
        /// <param name="size"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<int> GetPages(int index,int size,int total)
        {
            List<int> pages = new List<int>();
            int totalPages = (total % size == 0) ? (total / size) : (total / size) + 1;
            this.totalPages = totalPages;
            int endPage = totalPages - index > 10 ? index + 10 : totalPages+1;
            int startPage = index - 0 > 10 ? index - 10 : 1;
            for (int i = startPage; i < endPage; i++)
            {
                pages.Add(i);
            }
            return pages;
        }
    }
}