using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAFESA_Enrolment_System.Models
{
    /// <summary>
    /// Represents a singular subject enrolled for each student, containing the date enrolled, grade received (null for no grade yet) and semester for which the subject belongs to for this student.
    /// </summary>
    internal class Enrollment
    {
        static readonly DateTime DEFAULT_DATE_ENROLLED = DateTime.MinValue;
        const string? DEFAULT_GRADE = null;
        const int DEFAULT_SEMESTER = 0;

        public Subject Subject { get; set; }
        public DateTime DateEnrolled { get; set; }
        public string? Grade { get; set; }
        public int Semester { get; set; }

        /// <summary>
        /// No arg constructor (defaults)
        /// </summary>
        public Enrollment() : this(new Subject(), DEFAULT_DATE_ENROLLED, DEFAULT_GRADE, DEFAULT_SEMESTER) { }

        /// <summary>
        /// All arg constructor
        /// </summary>
        /// <param name="subject">Subject student enrolls into</param>
        /// <param name="dateEnrolled">DateTime object representing when enrolled</param>
        /// <param name="grade">Grade received for completed subject, nullable for incomplete subjects</param>
        /// <param name="semester">Semester in which subject is studied, either 1 or 2, 0 represents no arg default</param>
        public Enrollment(Subject subject, DateTime dateEnrolled, string? grade, int semester)
        {
            Subject = subject;
            DateEnrolled = dateEnrolled;
            Grade = grade;
            Semester = semester;
        }

        public override string ToString()
        {
            return $"Subject: {Subject}, DateEnrolled: {DateEnrolled}, Grade: {Grade}, Semester: {Semester}";
        }
    }
}
