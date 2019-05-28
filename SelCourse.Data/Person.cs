using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace SelCourse.Data
{
    /// <summary>
    ///  1. 主键如果不需要自增，需要增加该段代码 [DatabaseGenerated(DatabaseGeneratedOption.None)]
    ///  2.[DisplayName("名称"),Required,StringLength(50)]  [NotMapped]
    ///  3.[Table("Product", Schema = "dbo")]
    ///  4.[Required, Column("ProductName")]
    ///  5.[Column("UnitPrice", TypeName = "MONEY")]
    ///  6.[ForeignKey("CatID")]
    ///  7. https://www.cnblogs.com/libingql/p/3353112.html  
    ///    多个表之间的关系，配置，（用户，角色） 配置
    /// codeFirst,modelFirst
    /// </summary>
    public class Person
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        
        public int Age { get; set; }

        public string Address { get; set; }

        public DateTime  BeTime { get; set; }

        public decimal Money { get; set; }

        public string Area { get; set; }

        public bool Status { get; set; }
    }
}
