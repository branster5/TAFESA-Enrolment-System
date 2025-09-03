using TAFESA_Enrolment_System.Models;

namespace TAFESA_Enrolment_System
{
    class Program
    {
        static void Main(string[] args)
        {
            // SUBJECT:

            // Test subject constructors
            Subject noArgSubject = new Subject();
            Subject allArgSubject = new Subject("AAA", "Apply Anything Always", 999.99M);
            Console.WriteLine(noArgSubject);
            Console.WriteLine(allArgSubject);

            // Test Setters and Getters
            allArgSubject.SubjectName = "TestName";
            allArgSubject.SubjectCode = "TestCode";
            allArgSubject.Cost += 0.01M;
            Console.WriteLine("After updates:");
            Console.WriteLine("Code: " + allArgSubject.SubjectCode);
            Console.WriteLine("Name: " + allArgSubject.SubjectName);
            Console.WriteLine("Cost: " + allArgSubject.Cost);
        }
    }
}