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

            // Console line gap between types:
            Console.WriteLine("");
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

            // Console line gap between types:
            Console.WriteLine("");
            // ADDRESS:

            Console.WriteLine("PERSON TESTING: ");
            //Test address constructors
            Person noArgPerson = new Person();
            Person allArgPerson = new Person(allArgAddress, "John Doe", "johndoe@dodo.com", "+61 440 123 456");
            Console.WriteLine(noArgPerson);
            Console.WriteLine(allArgPerson);

            // Test setters and getters
            allArgPerson.Address = noArgAddress;
            allArgPerson.Name = "Not Real";
            allArgPerson.Email = "notreal@email.com";
            allArgPerson.PhoneNumber = "000000000";
            Console.WriteLine("After updates:");
            Console.WriteLine("Address: " + allArgPerson.Address);
            Console.WriteLine("Name: " + allArgPerson.Name);
            Console.WriteLine("Email: " + allArgPerson.Email);
            Console.WriteLine("Phone Number: " + allArgPerson.PhoneNumber);

            // Console line gap between types:
            Console.WriteLine("");
            // ADDRESS:

            Console.WriteLine("STUDENT TESTING: ");
            //Test address constructors
            Student noArgStudent = new Student();
            List<Enrollment> testEnrollmentList = new List<Enrollment>();
            testEnrollmentList.Add(new Enrollment());
            Student allArgStudent = new Student(testEnrollmentList, 123, "Diploma of Advanced Programming", DateTime.UtcNow, allArgAddress, "John Doe", "test@email.com", "8290 2390");
            testEnrollmentList.Add(allArgEnrollment);
            Student additionalArgStudent = new Student(testEnrollmentList, 321, "Certificate of Programming", DateTime.UtcNow, allArgPerson);
            Console.WriteLine(noArgStudent);
            Console.WriteLine(allArgStudent);
            Console.WriteLine(additionalArgStudent);

            // Test setters and getters
            //allArgStudent.StudentID = 999;
            allArgStudent.Program = "Diploma of Arts";
            allArgStudent.DateRegistered = allArgStudent.DateRegistered.AddYears(-2);
            Console.WriteLine("After updates:");
            //Console.WriteLine("Student ID: " + allArgStudent.StudentID);
            Console.WriteLine("Program: " + allArgStudent.Program);
            Console.WriteLine("Date Registered: " + allArgStudent.DateRegistered);

            Console.WriteLine("");

            Console.WriteLine("Test overwritten Student equals:");
            Console.WriteLine("Not equivalent students: ");
            Console.WriteLine(allArgStudent.Equals(noArgStudent));
            Console.WriteLine(allArgStudent == noArgStudent);
            Console.WriteLine("Test != ");
            Console.WriteLine(allArgStudent != noArgStudent);
            Student allArgStudent2 = new Student(testEnrollmentList, 123, "Diploma of Advanced Programming", DateTime.UtcNow, allArgAddress, "Jane Doe", "test@email.com", "8290 2390");
            Console.WriteLine("Equivalent students: ");
            Console.WriteLine(allArgStudent.Equals(allArgStudent2));
            Console.WriteLine(allArgStudent == allArgStudent2);
            Console.WriteLine("Test != ");
            Console.WriteLine(allArgStudent != allArgStudent2);

            Console.WriteLine("HashCodes:");
            Console.WriteLine(allArgStudent.GetHashCode());
            Console.WriteLine(allArgStudent2.GetHashCode());
            Console.WriteLine(allArgStudent.GetHashCode() == allArgStudent2.GetHashCode());
            Console.WriteLine(noArgStudent.GetHashCode());
            Console.WriteLine(allArgStudent.GetHashCode());
            Console.WriteLine(noArgStudent.GetHashCode() == allArgStudent.GetHashCode());
        }
    }
}