using System;

namespace App.Topics.StructArrays.T4_1_StudentStats
{
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
                throw new InvalidOperationException();

            long sum = 0;
            foreach (var student in students)
                sum += student.Score;

            return (double)sum / students.Length;
        }

        public static int MaxScore(Student[] students)
        {
            if (students == null)
                throw new ArgumentNullException(nameof(students));
            if (students.Length == 0)
                throw new InvalidOperationException();

            int max = students[0].Score;
            for (int i = 1; i < students.Length; i++)
            {
                if (students[i].Score > max)
                    max = students[i].Score;
            }
            return max;
        }

        public static int CountPassed(Student[] students)
        {
            if (students == null)
                throw new ArgumentNullException(nameof(students));

            int count = 0;
            foreach (var student in students)
            {
                if (student.Score >= 60)
                    count++;
            }
            return count;
        }

        public static Student[] NormalizeScores(Student[] students)
        {
            if (students == null)
                throw new ArgumentNullException(nameof(students));
            if (students.Length == 0)
                return Array.Empty<Student>();

            int min = students[0].Score;
            int max = students[0].Score;
            for (int i = 1; i < students.Length; i++)
            {
                if (students[i].Score < min) min = students[i].Score;
                if (students[i].Score > max) max = students[i].Score;
            }

            var result = new Student[students.Length];

            if (min == max)
            {
                for (int i = 0; i < students.Length; i++)
                {
                    result[i] = new Student(students[i].Name, 0);
                }
            }
            else
            {
                for (int i = 0; i < students.Length; i++)
                {
                    int normalizedScore = (students[i].Score - min) * 100 / (max - min);
                    result[i] = new Student(students[i].Name, normalizedScore);
                }
            }

            return result;
        }
    }
}