using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.Models {
    public class Student {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentProgram { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime GraduationDate { get; set; }
    }
}
