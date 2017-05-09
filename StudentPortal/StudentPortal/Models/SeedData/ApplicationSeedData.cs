using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.Models.SeedData {
    public class ApplicationSeedData {
        private ILoggerFactory _logger;
        private SchoolDatabaseContext _context;

        public ApplicationSeedData(ILoggerFactory logger, SchoolDatabaseContext context) {
            _logger = logger;
            _context = context;
        }

        public async Task EnsureSeedData() {

            if (!_context.Students.Any()) {
                var studentList = new List<Student>() {
                    new Student { StudentName = "Daniel Jackson", StudentProgram = "AS", StartDate = new DateTime(2015, 01, 01), GraduationDate = new DateTime(2019) },
                    new Student { StudentName = "Phyllis LaMonica", StudentProgram = "AS", StartDate = new DateTime(2015, 01, 01), GraduationDate = new DateTime(2019) },
                    new Student { StudentName = "Jacob Jacobs", StudentProgram = "BS", StartDate = new DateTime(2015, 01, 01), GraduationDate = new DateTime(2019) },
                    new Student { StudentName = "Alan Miller", StudentProgram = "MS", StartDate = new DateTime(2015, 01, 01), GraduationDate = new DateTime(2019) },
                    new Student { StudentName = "April O'Neill", StudentProgram = "PhD", StartDate = new DateTime(2015, 01, 01), GraduationDate = new DateTime(2019) },
                };

                await _context.AddRangeAsync(studentList);

                var professorList = new List<Professor>() {
                    new Professor { ProfessorName = "Anindya Paul" },
                    new Professor { ProfessorName = "Luke Sui"}
                };

                await _context.AddRangeAsync(professorList);

                //var classList = new List<Class> {
                //    new Class { ClassName = "Science", ProgramName = new List<String> { "AA", "AS", "BS", "BA", "MA", "PhD" } },
                //    new Class { ClassName = "Math", ProgramName = new List<String> { "AA", "AS", "BS", "BA", "MA", "PhD" } },
                //    new Class { ClassName = "C#", ProgramName = new List<String> { "AA", "AS" } },
                //    new Class { ClassName = "Adv. Astrophysics", ProgramName = new List<String> { "MA", "PhD" } }
                //};

                
                //studentSelect.

                var scheduledClassList = new List<ScheduledClass>() {
                    new ScheduledClass { ClassName = "C#", StartDate = new DateTime(2017, 06, 01), EndDate = new DateTime(2017, 08, 09) },
                    new ScheduledClass { ClassName = "Software Design & Analysis", StartDate = new DateTime(2017, 06, 01), EndDate = new DateTime(2017, 08, 09) }
                };
                await _context.AddRangeAsync(scheduledClassList);
                await _context.SaveChangesAsync();

                var classSchedule = await _context.StudentClasses
                    .Include(c => c.ScheduledStudents)
                    .SingleAsync(c => c.ScheduledId == 1);
                //classSchedule.ScheduledStudent = new List<Student>();
                classSchedule.ScheduledStudents.Add(_context.Students
                    .Single(s => s.StudentId == 1));
                classSchedule.ScheduledStudents.Add(_context.Students
                    .Single(s => s.StudentId == 2));
                await _context.SaveChangesAsync();
                //studentSelect.StudentProgram = _context.StudentClasses.Single(sc => sc.ScheduledId == 1);

                var progressBarList = new List<ProgressBar>() {
                    new ProgressBar { BarSize = 10 },
                    new ProgressBar { BarSize = 10 },
                    new ProgressBar { BarSize = 10 }
                };
                await _context.AddRangeAsync(progressBarList);
                //await _context.AddRangeAsync(classList);B
                await _context.SaveChangesAsync();

                // Set C# scheduled class professor to Luke Suit
                var scheduledClass = _context.StudentClasses.Single(sc => sc.ScheduledId == 1);
                scheduledClass.ClassProfessor = _context.Professors.Single(p => p.ProfessorId == 2);
                await _context.SaveChangesAsync();

                // Set software design class professor to Anindya Paul
                scheduledClass = _context.StudentClasses.Single(sc => sc.ScheduledId == 2);
                scheduledClass.ClassProfessor = _context.Professors.Single(p => p.ProfessorId == 1);
                await _context.SaveChangesAsync();

                var progressBar = _context.ProgressBars.Single(pb => pb.BarId == 1);
                progressBar.Student = await _context.Students.SingleAsync(s => s.StudentId == 1);
                progressBar = _context.ProgressBars.Single(pb => pb.BarId == 2);
                progressBar.Student = await _context.Students.SingleAsync(s => s.StudentId == 2);
                progressBar = _context.ProgressBars.Single(pb => pb.BarId == 3);
                progressBar.Student = await _context.Students.SingleAsync(s => s.StudentId == 3);
                await _context.SaveChangesAsync();

                var scheduledClassList2 = new List<ScheduledClass>() {
                new ScheduledClass { ClassName = "Math" },
                new ScheduledClass { ClassName = "History" },
                new ScheduledClass { ClassName = "English" }
            };

                await _context.SaveChangesAsync();
                //progressBar.ClassCompleted = ;
            }

        }
    }
}
