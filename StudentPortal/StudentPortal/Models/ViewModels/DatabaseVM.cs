using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.Models.ViewModels {
    public class DatabaseVM {
        public int Id { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Professor> Professors { get; set; }
        public ICollection<ScheduledClass> ScheduledClasses { get; set; }
        public ICollection<ProgressBar> ProgressBars { get; set; }

    }
}
