using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelCourse.Data
{
     public class Student
    {
        [Key]
        public int SId { get; set; }

        public string Number { get; set; }

        public int SchoolId { get; set; }

        public int GradeId { get; set; }

        public string Hobby { get; set; }

        public virtual ClassRoom classRoom{ get;set;}
    }
}
