using Microsoft.EntityFrameworkCore;
using StudentPortal.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.Models {
    public class SchoolDatabaseContext : DbContext {
        public SchoolDatabaseContext(DbContextOptions options) {
            //Database.EnsureCreated();
            //Database.Migrate();
        }
        public DbSet<ScheduledClass> StudentClasses { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<ProgressBar> ProgressBars { get; set; }
        public DbSet<DatabaseVM> DatabaseVM { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=tcp:daytonastate.database.windows.net,1433;Initial Catalog=DSCDatabase;Persist Security Info=False;User ID=danj210;Password=2Acq628210;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            //optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDb;Database=DSCDatabase;Trusted_Connection=true;MultipleActiveResultSets=true;");
            // To use a config file when ready
            //optionsBuilder.UseSqlServer(_config[""]);
        }
    }
}
