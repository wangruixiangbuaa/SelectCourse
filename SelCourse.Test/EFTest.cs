using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SelCourse.Data;

/// <summary>
/// https://www.cnblogs.com/libingql/p/3381571.html EF 查询数据   
/// 延迟加载（Lazy Loading）、贪婪加载（Eager Loading）以及显示加载（Explicit Loading）。
/// entity framework 提供数据
/// </summary>
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
                cl.Hobby = "乒乓球";
                cl.Number = "NO123";
                cl.SchoolId = 2;
                db.Students.Add(cl);
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void AddClass()
        {
            using (EFCodeFirstDBContext db = new EFCodeFirstDBContext())
            {
                ClassRoom room = new ClassRoom();
                room.ClassName = ".net";
                room.SchoolName = "厚溥";
                db.Classes.Add(room);
                db.SaveChanges();
            }
        }

        [TestMethod]
        public void GetClassById()
        {
            using (EFCodeFirstDBContext db = new EFCodeFirstDBContext())
            {
                var cls = db.Classes.Find(1);
                Assert.AreEqual(cls.Students.Count,1);
            }
        }

        [TestMethod]
        public void GetClassByIds()
        {
            using (EFCodeFirstDBContext db = new EFCodeFirstDBContext())
            {
                var cls = db.Classes.Find(1);
                db.Entry(cls).Collection(p => p.Students)
                    .Query();
                Assert.AreEqual(cls.Students.Count, 1);
            }
        }
    }
}
