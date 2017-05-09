using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.Models {
    public class ScheduledClass {
        [Key]
        public int ScheduledId { get; set; }
        public string ClassName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Professor ClassProfessor { get; set; }
        public ICollection<Student> ScheduledStudents { get; set; }
    }
}
