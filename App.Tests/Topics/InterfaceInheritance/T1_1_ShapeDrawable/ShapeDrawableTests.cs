using App.Topics.InterfaceInheritance.T1_1_ShapeDrawable;

namespace App.Tests.Topics.InterfaceInheritance.T1_1_ShapeDrawable;

public class ShapeDrawableTests
{
    [Test]
    public void Circle_BadRadius_Throws()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(0));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Circle(-1));
    }

    [Test]
    public void Rectangle_BadSides_Throws()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Rectangle(0, 1));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Rectangle(1, 0));
        Assert.Throws<ArgumentOutOfRangeException>(() => new Rectangle(-2, 2));
    }

    [Test]
    public void Circle_Calculates_Area_And_Perimeter()
    {
        // r = 3
        var c = new Circle(3);
        Assert.That(Math.Round(c.Area, 4), Is.EqualTo(Math.Round(Math.PI * 9, 4)));
        Assert.That(Math.Round(c.Perimeter, 4), Is.EqualTo(Math.Round(2 * Math.PI * 3, 4)));
        Assert.That(c.Draw(), Does.Contain("Circle").And.Contain("3"));
    }

    [Test]
    public void Rectangle_Calculates_Area_And_Perimeter()
    {
        var r = new Rectangle(2.5, 4);
        Assert.That(r.Area, Is.EqualTo(10));
        Assert.That(r.Perimeter, Is.EqualTo(2 * (2.5 + 4)));
        Assert.That(r.Draw(), Does.Contain("Rectangle").And.Contain("2.5").And.Contain("4"));
    }
}
