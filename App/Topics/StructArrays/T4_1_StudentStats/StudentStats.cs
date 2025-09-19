// Тема 4, Задача T4.1_StudentStats
// Работа с массивами структур и простыми аналитическими функциями.

namespace App.Topics.StructArrays.T4_1_StudentStats;

public readonly struct Student
{
    public string Name { get; }
    public int Score { get; }
    public Student(string name, int score)
    {
        // Требуется: name не null/empty, score в диапазоне [0..100]
        throw new NotImplementedException();
    }
}

public static class StudentAnalytics
{
    // Средний балл. Пустой массив — InvalidOperationException. null — ArgumentNullException.
    public static double AverageScore(Student[] students) => throw new NotImplementedException();

    // Максимальный балл. Пустой массив — InvalidOperationException. null — ArgumentNullException.
    public static int MaxScore(Student[] students) => throw new NotImplementedException();

    // Считает, сколько сдали (>= 60)
    public static int CountPassed(Student[] students) => throw new NotImplementedException();

    // Возвращает новый массив с нормализованными баллами в диапазоне [0..100].
    // Если min==max, верните копию исходного массива.
    public static Student[] NormalizeScores(Student[] students) => throw new NotImplementedException();
}
