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

            // ADDRESS:

            Console.WriteLine("ADDRESS TESTING: ");
            //Test address constructors
            Address noArgAddress = new Address();
            Address allArgAddress = new Address(10, "Unicorn Street", "Adelaide", 5000, "SA");
            Console.WriteLine(noArgAddress);
            Console.WriteLine(allArgAddress);

            // Test setters and getters
            allArgAddress.StreetNum = 100;
            allArgAddress.StreetName = "Gargoyle Street";
            allArgAddress.Suburb = "Wallaroo";
            allArgAddress.Postcode = 5430;
            allArgAddress.State = "WA";
            Console.WriteLine("After updates:");
            Console.WriteLine("Street Number: " + allArgAddress.StreetNum);
            Console.WriteLine("Street Name: " + allArgAddress.StreetName);
            Console.WriteLine("Suburb: " + allArgAddress.Suburb);
            Console.WriteLine("Postcode: " + allArgAddress.Postcode);
            Console.WriteLine("State: " + allArgAddress.State);
        }
    }
}