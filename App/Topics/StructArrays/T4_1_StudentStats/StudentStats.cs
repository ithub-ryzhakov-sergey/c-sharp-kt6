using System;

namespace App.Topics.StructArrays.T4_1_StudentStats;

    public readonly struct Student
    {
        public string Name { get; }
        public int Score { get; }

        public Student(string name, int score)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name не может быть пустым или null", nameof(name));
            if (score < 0 || score > 100)
                throw new ArgumentOutOfRangeException(nameof(score), "score должен быть мкежду 0 и 100");

            Name = name;
            Score = score;
        }
    }

public static class StudentAnalytics
{
    public static double AverageScore(Student[] students)
    {
        if (students == null)
            throw new ArgumentNullException(nameof(students));

        if (students.Length == 0)
            throw new InvalidOperationException("массив c students пустой");

        return students.Average(s => s.Score);
    }

    public static int MaxScore(Student[] students)
    {
        if (students == null)
            throw new ArgumentNullException(nameof(students));

        if (students.Length == 0)
            throw new InvalidOperationException("массив c students пустой");

        return students.Max(s => s.Score);
    }

    public static int CountPassed(Student[] students)
    {
        if (students == null)
            throw new ArgumentNullException(nameof(students));

        return students.Count(s => s.Score >= 60);
    }
}

