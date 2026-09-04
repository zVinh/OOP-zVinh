using System;
class Program
{
    static void Main(string[] args)
    {
        // TODO: create array of Student objects
        Student[] students = {
                new Student("Le The Vinh", 8.5),
                new Student("Phan Tan Phat", 7.2),
                new Student("Pham Hung",9.0),
                new Student("Le Phuong Trinh", 6.0),
                new Student("Nguyen Thanh Dat",4.5)
            };


        // TODO: call static and instance methods as required
        //Total Student
        Console.WriteLine("Total Student " + Student.GetTotalStudents());
        //List Student 

        Console.WriteLine("List Student");
        foreach (Student student in students)
            Console.WriteLine("Name: " + student.GetName() +
            ", Score: " + student.GetScore() +
            ", Classification: " + student.GetClassification() +
            ", Status: " + (student.IsPassed() ? "Pass" : "Fail")
        );
        //Top student
        Student topStudent = Student.FindTopStudent(students);
        Console.WriteLine("Top student " + topStudent.GetName() + " - " + topStudent.GetScore()
            );
        // Calculate average score
        double averageScore = Student.CalculateAverageScore(students);

        Console.WriteLine(
                "\nClass average score: " +
                averageScore.ToString("F2")
            );
    }

}
