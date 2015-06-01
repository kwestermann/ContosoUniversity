using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{

    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        //The Grade property is an enum. The question mark after the Grade type declaration 
        //indicates that the Grade property is nullable. A grade that's null is different 
        //from a zero grade — null means a grade isn't known or hasn't been assigned yet.

        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
        
    }
}