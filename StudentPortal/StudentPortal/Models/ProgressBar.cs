using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.Models {
    public class ProgressBar {
        [Key]
        public int BarId { get; set; }
        public int BarSize { get; set; }
        public ICollection<ScheduledClass> ClassCompleted { get; set; }
        public Student Student { get; set; }
    }
}
