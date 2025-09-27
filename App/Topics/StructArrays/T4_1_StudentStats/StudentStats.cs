// Тема 4, Задача T4.1_StudentStats
// Работа с массивами структур и простыми аналитическими функциями.

namespace App.Topics.StructArrays.T4_1_StudentStats;
public readonly struct Student
{
    public string Name { get; }
    public int Score { get; }


    public Student(string name, int score)
    {
        if (name == null) throw new ArgumentNullException("name");
        if (name.Length == 0) throw new ArgumentException("name");

        if (score < 0 || score > 100) throw new ArgumentOutOfRangeException();


        Name = name;
        Score = score;
    }
}

public static class StudentAnalytics
{
    public static double AverageScore(Student[] students)
    {
        return students
            .Select(student => student.Score)
            .Average();
    }

    public static int MaxScore(Student[] students)
    {
        return students
         .Max(student => student.Score);
             
    }


    public static int CountPassed(Student[] students)
    {
        return students
            .Where(student => student.Score > 60)
            .Count();
    }

}