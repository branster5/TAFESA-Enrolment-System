using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TAFESA_Enrolment_System.Models
{
    /// <summary>
    /// Student object which inherits person as its base object, 
    /// adding TAFE student specific data including student id, program being studied, date registered 
    /// and a list of enrollments the student is studying
    /// </summary>
    internal class Student : Person
    {
        const int DEFAULT_STUDENT_ID = 0;
        const string DEFAULT_PROGRAM = "No program given given";
        static readonly DateTime DEFAULT_DATE_REGISTERED = DateTime.MinValue;

        //No setter, simply add or remove enrollments instead of replacing the list
        public List<Enrollment> Enrollments { get; }
        public int StudentID { get; set; }
        public string Program { get; set; }
        public DateTime DateRegistered { get; set; }

        /// <summary>
        /// No arg constructor (defaults), taking defaults from person which it inherits
        /// </summary>
        public Student() : this(new List<Enrollment>(), DEFAULT_STUDENT_ID, DEFAULT_PROGRAM, DEFAULT_DATE_REGISTERED,
            new Address(), DEFAULT_NAME, DEFAULT_EMAIL, DEFAULT_PHONE_NUMBER) { }

        /// <summary>
        /// All arg constructor, second row of inputs represents those inherited from the person object
        /// </summary>
        /// <param name="enrollments">List of enrollments student currently has, cannot be replaced entirely, instead remove or add enrollment objects</param>
        /// <param name="studentID">Unique student ID integer</param>
        /// <param name="program">Specific course type being studied</param>
        /// <param name="dateRegistered">DateTime object for when student first was entered into the system</param>
        /// <param name="address">Address object for where person lives</param>
        /// <param name="name">Name of person</param>
        /// <param name="email">Contact email</param>
        /// <param name="phoneNumber">Phone number (as string for formatting)</param>
        public Student(List<Enrollment> enrollments, int studentID, string program, DateTime dateRegistered,
            Address address, string name, string email, string phoneNumber)
        {
            this.Enrollments = enrollments;
            this.StudentID = studentID;
            this.Program = program;
            this.DateRegistered = dateRegistered;

            this.Address = address;
            this.Name = name;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// Additional constructor, if a person is already created, but not as a student object
        /// </summary>
        /// <param name="enrollments">List of enrollments student currently has, cannot be replaced entirely, instead remove or add enrollment objects</param>
        /// <param name="studentID">Unique student ID integer</param>
        /// <param name="program">Specific course type being studied</param>
        /// <param name="dateRegistered">DateTime object for when student first was entered into the system</param>
        /// <param name="person">Person object if already created instead of generating in all arg constructor</param>
        public Student(List<Enrollment> enrollments, int studentID, string program, DateTime dateRegistered,
            Person person)
        {
            this.Enrollments = enrollments;
            this.StudentID = studentID;
            this.Program = program;
            this.DateRegistered = dateRegistered;

            this.Address = person.Address;
            this.Name = person.Name;
            this.Email = person.Email;
            this.PhoneNumber = person.PhoneNumber;
        }

        public override string ToString()
        {
            string toStringObject = $"Name: {Name}, StudentID: {StudentID}, Address: {Address}, Email: {Email}, Phone Number: {PhoneNumber}, Program: {Program}, Date Registered: {DateRegistered}\nEnrolled In:\n";
            // Use foreach loop with new lines after each for best string display of all enrollments
            foreach (Enrollment enrollment in Enrollments)
            {
                toStringObject += enrollment.ToString() + "\n";
            }
            return toStringObject;
        }

        /// <summary>
        /// Override equals for the purpose of determining if two students are the same. StudentID should remain unique to each student and be a valid identifier for if 2 students are equivalent.
        /// </summary>
        /// <param name="obj">Student Object to compare to this Student</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(obj, this)) 
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            Student other = obj as Student;
            return this.StudentID == other.StudentID;
        }
    }
}
