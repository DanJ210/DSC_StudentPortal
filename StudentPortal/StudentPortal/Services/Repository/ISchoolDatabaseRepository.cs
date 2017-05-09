using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentPortal.Models;

namespace StudentPortal.Services.Repository {
    public interface ISchoolDatabaseRepository {
        /// <summary>
        /// Queries the database for all students.
        /// </summary>
        /// <returns>ICollection of Student</returns>
        Task<ICollection<Student>> GetStudents();
        /// <summary>
        /// Queries the database for all professors.
        /// </summary>
        /// <returns>ICollection of Professor.</returns>
        Task<ICollection<Professor>> GetProfessors();
        /// <summary>
        /// Queries the database for all scheduled classes.
        /// </summary>
        /// <returns>ICollection of ScheduledClass.</returns>
        Task<ICollection<ScheduledClass>> GetScheduledClasses();
        /// <summary>
        /// Queries the database for all progress bars.
        /// </summary>
        /// <returns>ICollection of ProgressBar.</returns>
        Task<ICollection<ProgressBar>> GetProgressBars();

        /// <summary>
        /// Queries database for a single student using student id
        /// </summary>
        /// <returns>Student</returns>
        Task<Student> GetStudent(int id);
        /// <summary>
        /// Queries database for a single professor using database id.
        /// </summary>
        /// <returns>Professor</returns>
        Task<Professor> GetProfessor(int id);
        /// <summary>
        /// Queries database for a single scheduled class using database id.
        /// </summary>
        /// <returns>ScheduledClass</returns>
        Task<ScheduledClass> GetScheduledClass(int id);
        /// <summary>
        /// Queries database for a single progress bar using database id.
        /// </summary>
        /// <returns>ProgressBar</returns>
        Task<ProgressBar> GetProgressBar(int id);

        /// <summary>
        /// Gets a scheduled class belonging to a student.
        /// </summary>
        /// <param name="studentId">Database id of a student attatched to requested class.</param>
        /// <returns>ScheduledClass</returns>
        Task<ICollection<ScheduledClass>> GetStudentClass(int studentId);
        /// <summary>
        /// Gets a progress bar belonging to a student.
        /// </summary>
        /// <param name="studentId">Database id of a student attatched to requested progress bar.</param>
        /// <returns>ProgressBar</returns>
        Task<ProgressBar> GetStudentProgressBar(int studentId);
    }
}
