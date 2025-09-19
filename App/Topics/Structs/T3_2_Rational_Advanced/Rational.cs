// Тема 3 (*), Задача T3.2_Rational
// Иммутабельная структура рационального числа с нормализацией и арифметикой.

namespace App.Topics.Structs.T3_2_Rational_Advanced;

public readonly struct Rational : IEquatable<Rational>, IComparable<Rational>
{
    public int Numerator { get; }
    public int Denominator { get; }

    public Rational(int numerator, int denominator)
    {
        // Требуется: denominator != 0, нормализация знака и сокращение дроби на НОД
        // Подсказка: используйте локальную функцию Gcd(int a, int b)
        throw new NotImplementedException();
    }

    public static Rational operator +(Rational a, Rational b) => throw new NotImplementedException();
    public static Rational operator -(Rational a, Rational b) => throw new NotImplementedException();
    public static Rational operator *(Rational a, Rational b) => throw new NotImplementedException();
    public static Rational operator /(Rational a, Rational b) => throw new NotImplementedException();

    public int CompareTo(Rational other) => throw new NotImplementedException();
    public bool Equals(Rational other) => throw new NotImplementedException();
    public override bool Equals(object? obj) => obj is Rational r && Equals(r);
    public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);

    public override string ToString() => $"{Numerator}/{Denominator}";
}
