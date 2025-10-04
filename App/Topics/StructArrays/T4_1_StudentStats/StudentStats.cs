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
        {
            throw new ArgumentNullException();
        }
        if (name.Trim() == "") {
            throw new ArgumentException();
        }
        if (score > 100 || score < 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        this.Name = name;
        this.Score = score;
    }
}
public static class StudentAnalytics
{
    public static double AverageScore(Student[] students)
    {
        if (students == null) {
            throw new ArgumentNullException();
        }
        if (students.Length == 0) {
            throw new InvalidOperationException();
        }
        int count = 0;
        double res = 0.0;
        foreach (var item in students)
        {
            count++;
            res += item.Score;
        }
        return res / count;
    }
    public static int MaxScore(Student[] students)
    {
        if (students == null) {
            throw new ArgumentNullException();
        }
        if (students.Length == 0) {
            throw new InvalidOperationException();
        }
        int max = int.MinValue;
        foreach (var item in students)
        {
            if (item.Score > max)
            {
                max = item.Score;
            }
        }
        return max;
    }
    public static int CountPassed(Student[] students)
    {
        if (students == null) {
            throw new ArgumentNullException();
        }
        if (students.Length == 0) {
            throw new InvalidOperationException();
        }
        int count = 0;
        foreach (var item in students)
        {
            if (item.Score >= 60)
            {
                count++;
            }
        }
        return count;
    }
}