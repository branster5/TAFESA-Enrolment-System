using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAFESA_Enrolment_System.Models
{
    /// <summary>
    /// Repesents a singular subject to learn inside of a enrollment, with an internal code, display name and cost associated.
    /// </summary>
    internal class Subject
    {
        const string DEFAULT_SUBJECT_CODE = "No subject code provided";
        const string DEFAULT_SUBJECT_NAME = "No subject name provided";
        const decimal DEFAULT_COST = 0;

        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public decimal Cost { get; set; }

        /// <summary>
        /// No arg constructor (defaults)
        /// </summary>
        public Subject() : this(DEFAULT_SUBJECT_CODE, DEFAULT_SUBJECT_NAME, DEFAULT_COST) { }

        /// <summary>
        /// All arg constructor
        /// </summary>
        /// <param name="subjectCode">Unique code</param>
        /// <param name="subjectName">Display subject name</param>
        /// <param name="cost">Tuition cost (decimal)</param>
        public Subject(string subjectCode, string subjectName, decimal cost)
        {
            SubjectCode = subjectCode;
            SubjectName = subjectName;
            Cost = cost;
        }

        public override string ToString()
        {
            return "SubjectCode: " + SubjectCode + ", SubjectName: " + SubjectName + ", Cost: " + Cost.ToString();
        }
    }
}
