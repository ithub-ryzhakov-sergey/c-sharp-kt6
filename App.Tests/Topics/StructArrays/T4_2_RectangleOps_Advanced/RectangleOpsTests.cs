using App.Topics.StructArrays.T4_2_RectangleOps_Advanced;

namespace App.Tests.Topics.StructArrays.T4_2_RectangleOps_Advanced;

[Category("*")]
public class RectangleOpsTests
{
    [Test]
    public void Rect_Validates_And_Computes()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Rect(0, 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Rect(1, 0));
        var r = new Rect(3, 4);
        Assert.That(r.Area, Is.EqualTo(12));
        Assert.That(r.Perimeter, Is.EqualTo(14));
        Assert.That(RectangleOps.Validate(r), Is.True);
    }

    [Test]
    public void TotalArea_And_BiggestPerimeter()
    {
        var rects = new[] { new Rect(1, 1), new Rect(2, 3), new Rect(10, 1) };
        Assert.That(RectangleOps.TotalArea(rects), Is.EqualTo(1 + 6 + 10));
        Assert.That(RectangleOps.BiggestPerimeter(rects), Is.EqualTo(2 * (10 + 1)));
    }

    [Test]
    public void Invalid_Data_Throws()
    {
        var rects = new[] { new Rect(1, 1), new Rect(0, 2) };
        Assert.Throws<ArgumentException>(() => RectangleOps.TotalArea(rects));
        Assert.Throws<ArgumentException>(() => RectangleOps.BiggestPerimeter(rects));
        Assert.Throws<InvalidOperationException>(() => RectangleOps.BiggestPerimeter(Array.Empty<Rect>()));
    }
}
