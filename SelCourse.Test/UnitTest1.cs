using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SelCourse.Data;

namespace SelCourse.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (EFCodeFirstDBContext db = new EFCodeFirstDBContext())
            {
                Person cl = new Person();
                cl.Address = "code first";
                cl.Age = 18;
                cl.BeTime = DateTime.Now;
                cl.Money = 12.5M;
                cl.Name = "ef2";
                db.TestClasses.Add(cl);
                db.SaveChanges();
            }
        }
    }
}
