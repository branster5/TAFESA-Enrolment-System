using TAFESA_Enrolment_System.Models;

namespace TAFESA_Enrolment_System
{
    class Program
    {
        static void Main(string[] args)
        {
            // SUBJECT:

            Console.WriteLine("SUBJECT TESTING: ");
            // Test subject constructors
            Subject noArgSubject = new Subject();
            Subject allArgSubject = new Subject("AAA", "Apply Anything Always", 999.99M);
            Console.WriteLine(noArgSubject);
            Console.WriteLine(allArgSubject);

            // Test setters and getters
            allArgSubject.SubjectName = "TestName";
            allArgSubject.SubjectCode = "TestCode";
            allArgSubject.Cost += 0.01M;
            Console.WriteLine("After updates:");
            Console.WriteLine("Code: " + allArgSubject.SubjectCode);
            Console.WriteLine("Name: " + allArgSubject.SubjectName);
            Console.WriteLine("Cost: " + allArgSubject.Cost);

            // Console line gap between types:
            Console.WriteLine("");

            //ENROLLMENT:

            Console.WriteLine("ENROLLMENT TESTING: ");
            //Test enrollment constructors
            Enrollment noArgEnrollment = new Enrollment();
            Enrollment allArgEnrollment = new Enrollment(allArgSubject, DateTime.UtcNow, null, 1);
            Console.WriteLine(noArgEnrollment);
            Console.WriteLine(allArgEnrollment);

            // Test setters and getters
            allArgEnrollment.Subject = noArgSubject;
            allArgEnrollment.DateEnrolled = allArgEnrollment.DateEnrolled.AddYears(-1);
            allArgEnrollment.Grade = "HD";
            allArgEnrollment.Semester = 2;
            Console.WriteLine("After updates:");
            Console.WriteLine("Subject: " + allArgEnrollment.Subject);
            Console.WriteLine("Date Enrolled: " + allArgEnrollment.DateEnrolled);
            Console.WriteLine("Grade: " + allArgEnrollment.Grade);
            Console.WriteLine("Semester: " + allArgEnrollment.Semester);
        }
    }
}