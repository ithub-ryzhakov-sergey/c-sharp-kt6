using App.Topics.StructArrays.T4_1_StudentStats;

namespace App.Tests.Topics.StructArrays.T4_1_StudentStats;

public class StudentStatsTests
{
    [Test]
    public void Average_And_Max_Basic()
    {
        var data = new[]
        {
             new Student("A", 100),
             new Student("B", 80),
             new Student("C", 60),
         };
        Assert.That(StudentAnalytics.AverageScore(data), Is.EqualTo((100 + 80 + 60) / 3.0));
        Assert.That(StudentAnalytics.MaxScore(data), Is.EqualTo(100));
    }

    [Test]
    public void Null_Or_Empty_Handling()
    {
        Assert.Throws<ArgumentNullException>(() => StudentAnalytics.AverageScore(null!));
        Assert.Throws<InvalidOperationException>(() => StudentAnalytics.AverageScore(Array.Empty<Student>()));
        Assert.Throws<ArgumentNullException>(() => StudentAnalytics.MaxScore(null!));
        Assert.Throws<InvalidOperationException>(() => StudentAnalytics.MaxScore(Array.Empty<Student>()));
    }

    [Test]
    public void CountPassed_And_Normalize()
    {
        var data = new[]
        {
             new Student("A", 10),
             new Student("B", 60),
             new Student("C", 90),
         };
        Assert.That(StudentAnalytics.CountPassed(data), Is.EqualTo(2));
        var normalized = StudentAnalytics.NormalizeScores(data);
        Assert.That(normalized, Has.Length.EqualTo(3));
        Assert.That(normalized[0].Score, Is.EqualTo(0));
        Assert.That(normalized[1].Score, Is.EqualTo(50));
        Assert.That(normalized[2].Score, Is.EqualTo(100));
    }

    [Test]
    public void Student_Ctor_Validates()
    {
        Assert.Throws<ArgumentNullException>(() => new Student(null!, 10));
        Assert.Throws<ArgumentException>(() => new Student("", 10));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Student("A", -1));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Student("A", 101));
    }
}