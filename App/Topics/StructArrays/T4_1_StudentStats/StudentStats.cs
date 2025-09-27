// Тема 4, Задача T4.1_StudentStats
// Работа с массивами структур и простыми аналитическими функциями.

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
            throw new ArgumentException(nameof(name));

        if (score < 0 || score > 100)
            throw new ArgumentOutOfRangeException(nameof(score));

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
            throw new InvalidOperationException("empty");

        return students.Average(s => s.Score);
    }

    public static int MaxScore(Student[] students)
    {
        if (students == null)
            throw new ArgumentNullException(nameof(students));

        if (students.Length == 0)
            throw new InvalidOperationException("empty");

        return students.Max(s => s.Score);
    }

    public static int CountPassed(Student[] students)
    {
        if (students == null)
            throw new ArgumentNullException(nameof(students));

        return students.Count(s => s.Score >= 60);
    }

    public static Student[] NormalizeScores(Student[] students)
    {
        if (students == null)
            throw new ArgumentNullException(nameof(students));

        if (students.Length == 0)
            return students;

        int minScore = students.Min(s => s.Score);
        int maxScore = students.Max(s => s.Score);

        if (minScore == maxScore)
            return students;

        return students.Select(s =>
        {
            int normalizedScore = (s.Score - minScore) * 100 / (maxScore - minScore);
            return new Student(s.Name, normalizedScore);
        }).ToArray();
    }
}