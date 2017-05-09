using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentPortal.Services.Repository {
    public class SchoolDatabaseRepository : ISchoolDatabaseRepository {
        private SchoolDatabaseContext _context;

        public SchoolDatabaseRepository(SchoolDatabaseContext context) {
            _context = context;
        }

        public async Task<ICollection<Student>> GetStudents() {
            return await _context.Students.ToListAsync();
        }
        public async Task<Student> GetStudent(int id) {
            return await _context.Students
                .Include(sp => sp.StudentProgram)
                .SingleAsync(s => s.StudentId == id);
        }
        public async Task<ICollection<Professor>> GetProfessors() {
            return await _context.Professors.ToListAsync();
        }
        public async Task<Professor> GetProfessor(int id) {
            return await _context.Professors
                //.Include()
                .SingleAsync(p => p.ProfessorId == id);
        }

        public async Task<ICollection<ScheduledClass>> GetScheduledClasses() {
            return await _context.StudentClasses.ToListAsync();
        }
        public async Task<ScheduledClass> GetScheduledClass(int id) {
            return await _context.StudentClasses
                .Include(sc => sc.ScheduledStudents)
                .Include(sp => sp.ClassProfessor)
                .SingleAsync(sc => sc.ScheduledId == id);
        }
        public async Task<ICollection<ProgressBar>> GetProgressBars() {
            return await _context.ProgressBars.ToListAsync();
        }
        public async Task<ProgressBar> GetProgressBar(int id) {
            return await _context.ProgressBars
                .Include(pb => pb.ClassCompleted)
                .SingleAsync(pb => pb.BarId == id);
        }

        /// <summary>
        /// Gets a list of all classes assigned to a student id.
        /// </summary>
        /// <param name="studentId">Int - Database id of a student.</param>
        /// <returns>IEnumerable of ScheduledClass</returns>
        public async Task<ICollection<ScheduledClass>> GetStudentClass(int studentId) {
            var scheduledClassList = await _context.StudentClasses.ToListAsync();
            return scheduledClassList.FindAll(s => s.ScheduledId == studentId);
            //return await _context.StudentClasses
            //    .Where(sc => sc.ScheduledStudents.Where(s => s.StudentId == studentId));
        }
        public async Task<ProgressBar> GetStudentProgressBar(int studentId) {
            var progressBarList = await _context.ProgressBars.ToListAsync();
            return progressBarList.Single(pb => pb.Student.StudentId == studentId);
        }

    }
}
