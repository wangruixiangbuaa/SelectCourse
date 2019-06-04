using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelCourse.Data
{
    public class EFCodeFirstDBContext:DbContext
    {
        /// <summary>
        /// 1.configSection 需要放到第一位，否则的话会报错，错误信息为：加载类型失败
        /// 2.如果主键重复往数据库表里添加数据的时候，同样会报错。
        /// 3.如果修改了模型，如何更新数据库模型，需要三步,如果迁移失败，（没有把当前迁移的项目设置为启动项）
        ///    3.1 启用指定DBContext迁移   Enable-Migrations -EnableAutomaticMigrations  Enable-Migrations -EnableAutomaticMigrations -Force
        ///    3.2 添加迁移配置   Add-Migration  name(XXX)  InitialCreate
        ///    3.3 更新数据库     Update-Database -Verbose
        /// ->可能遇到的问题：
        /// 启用迁移的项目可能与启动项目不同。
        /// 错误的实体框架版本。
        /// 错误的连接字符串或双连接字符串。
        /// </summary>
        public EFCodeFirstDBContext() : base("name=MyStrConn")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EFCodeFirstDBContext>());
            //Database.SetInitializer<EFCodeFirstDBContext>(null);
        }
        public DbSet<Person> Persons { get; set; }

        public DbSet<Student> Students { get; set; }


        public DbSet<ClassRoom> Classes { get; set; }
    }
}
