using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SelCourse.Data;

namespace SelCourse.Test
{
    [TestClass]
    public class EFTest
    {
        [TestMethod]
        public void AddPersonMethod()
        {
            using (EFCodeFirstDBContext db = new EFCodeFirstDBContext())
            {
                Person cl = new Person();
                cl.Address = "code first";
                cl.Age = 18;
                cl.BeTime = DateTime.Now;
                cl.Money = 12.5M;
                cl.Name = "ef2";
                db.Persons.Add(cl);
                db.SaveChanges();
            }
        }


        [TestMethod]
        public void AddStudentMethod()
        {
            using (EFCodeFirstDBContext db = new EFCodeFirstDBContext())
            {
                Student cl = new Student();
                cl.ClassId = 1;
                cl.Hobby = "乒乓球";
                cl.Number = "NO123";
                cl.SchoolId = 2;
                db.Students.Add(cl);
                db.SaveChanges();
            }
        }
    }
}
