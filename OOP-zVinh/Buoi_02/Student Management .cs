using System;

public class Student
{
    private string name;
    private double score;
    private static int totalStudents = 0;

    public Student(string name, double score)
    {
        this.name = name;
        this.score = score;
        totalStudents++;
    }

    // TODO: write instance methods here
    public string GetName()
    {
        return name;
    }
    public double GetScore()
    {
        return score;
    }

    public bool IsPassed()
    {
        if (score >= 5.0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public string GetClassification()
    {
        if (score >= 8.0)
        {
            return "Excellent";
        }
        else if (score >= 6.5)
        {
            return "Good";
        }
        else if (score >= 5.0)
        {
            return "Average";
        }
        else
        {
            return "Weak";
        }
    }
    // TODO: write static methods here
    public static int GetTotalStudents()
    {
        return totalStudents;
    }
    public static Student FindTopStudent(Student[] students)
    {
        Student topstudent = students[0];

        foreach (Student student in students)
        {
            if (student.score > topstudent.score)
            {
                topstudent = student;
            }
        }

        return topstudent;
    }
    public static double CalculateAverageScore(Student[] students)
    {
        double total = 0;
        foreach (Student student in students)
        {
            total += student.score;

        }
        return total / students.Length;
    }
}

    
