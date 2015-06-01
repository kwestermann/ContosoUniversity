using ContosoUniversity.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ContosoUniversity.DAL
{
    // This code creates a DbSet property for each entity set. In Entity Framework terminology,
    // an entity set typically corresponds to a database table, and an entity 
    // corresponds to a row in the table.
    public class SchoolContext : DbContext
    {
        // The name of the connection string (which you'll add to the Web.config file later) 
        // is passed in to the constructor.
        //public SchoolContext() : base("SchoolContext")
        //{
        //}

        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // The modelBuilder.Conventions.Remove statement in the OnModelCreating method 
            // prevents table names from being pluralized. 
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Instructors).WithMany(i => i.Courses)
                .Map(t => t.MapLeftKey("CourseID")
                    .MapRightKey("InstructorID")
                    .ToTable("CourseInstructor"));
        }
    }
}
