using System;
using System.Collections.Generic;
using System.Text;

namespace Home10EVENT
{
    public record class StudentGrades(string FullName, double[] Grades);
    public static class Student
    {
        public static double CalculateAverage(double[] grades)
        {
            if (grades == null || grades.Length == 0) return 0;
            double sum = 0;
            foreach (var grade in grades) sum += grade;
            return sum / grades.Length;
        }
        public static StudentGrades GetStudentWithMaxAverage(StudentGrades[] students)
        {
            if (students == null || students.Length == 0) return null;
            StudentGrades bestStudent = students[0];
            double maxAverage = CalculateAverage(bestStudent.Grades);
            foreach (var student in students)
            {
                double currentAverage = CalculateAverage(student.Grades);
                if (currentAverage > maxAverage)
                {
                    maxAverage = currentAverage;
                    bestStudent = student;
                }
            }
            return bestStudent;
        }
    }
}
