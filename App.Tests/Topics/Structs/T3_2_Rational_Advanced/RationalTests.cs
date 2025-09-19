using App.Topics.Structs.T3_2_Rational_Advanced;

namespace App.Tests.Topics.Structs.T3_2_Rational_Advanced;

[Category("*")]
public class RationalTests
{
    [Test]
    public void Ctor_Validates_And_Normalizes()
    {
        Assert.Throws<DivideByZeroException>(() => new Rational(1, 0));
        var r = new Rational(-2, -4); // => 1/2
        Assert.That(r.Numerator, Is.EqualTo(1));
        Assert.That(r.Denominator, Is.EqualTo(2));

        var r2 = new Rational(2, -4); // => -1/2
        Assert.That(r2.Numerator, Is.EqualTo(-1));
        Assert.That(r2.Denominator, Is.EqualTo(2));
    }

    [Test]
    public void Operators_And_Compare()
    {
        var a = new Rational(1, 3);
        var b = new Rational(1, 6);
        Assert.That((a + b).ToString(), Is.EqualTo("1/2"));
        Assert.That((a - b).ToString(), Is.EqualTo("1/6"));
        Assert.That((a * b).ToString(), Is.EqualTo("1/18"));
        Assert.That((a / b).ToString(), Is.EqualTo("2/1"));
        Assert.That(a.CompareTo(b), Is.GreaterThan(0));
        Assert.That(a.Equals(new Rational(2, 6)), Is.True);
    }
}
