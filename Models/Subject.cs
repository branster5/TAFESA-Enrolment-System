using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAFESA_Enrolment_System.Models
{
    internal class Subject
    {
        const string DEF_SUBJECT_CODE = "No subject code provided";
        const string DEF_SUBJECT_NAME = "No subject name provided";
        const decimal DEF_COST = 0;
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public decimal Cost { get; set; }

        // No arg constructor
        public Subject() : this(DEF_SUBJECT_CODE, DEF_SUBJECT_NAME, DEF_COST) { }

        // All arg constructor
        public Subject(string subjectCode, string subjectName, decimal cost)
        {
            SubjectCode = subjectCode;
            SubjectName = subjectName;
            Cost = cost;
        }

        public override string ToString()
        {
            return "SubjectCode: " + SubjectCode + " SubjectName: " + SubjectName + " Cost: " + Cost.ToString();
        }
    }
}
