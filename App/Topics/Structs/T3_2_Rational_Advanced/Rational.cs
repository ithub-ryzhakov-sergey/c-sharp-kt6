// Тема 3 (*), Задача T3.2_Rational
// Иммутабельная структура рационального числа с нормализацией и арифметикой.

namespace App.Topics.Structs.T3_2_Rational_Advanced
{
    public readonly struct Rational : IEquatable<Rational>, IComparable<Rational>
    {
        public int Numerator { get; }
        public int Denominator { get; }

        public Rational(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new DivideByZeroException();

            int gcd = GCD(numerator, denominator);

            numerator /= gcd;
            denominator /= gcd;

            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }

            Numerator = numerator;
            Denominator = denominator;
        }

        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int t = b;
                b = a % b;
                a = t;
            }
            return Math.Abs(a);
        }

        public static Rational operator +(Rational a, Rational b) =>
            new Rational(
                a.Numerator * b.Denominator + b.Numerator * a.Denominator,
                a.Denominator * b.Denominator);

        public static Rational operator -(Rational a, Rational b) =>
            new Rational(
                a.Numerator * b.Denominator - b.Numerator * a.Denominator,
                a.Denominator * b.Denominator);

        public static Rational operator *(Rational a, Rational b) =>
            new Rational(
                a.Numerator * b.Numerator,
                a.Denominator * b.Denominator);

        public static Rational operator /(Rational a, Rational b) =>
            new Rational(
                a.Numerator * b.Denominator,
                a.Denominator * b.Numerator);

        public bool Equals(Rational other) =>
            Numerator == other.Numerator && Denominator == other.Denominator;

        public override bool Equals(object? obj) =>
            obj is Rational other && Equals(other);

        public override int GetHashCode() =>
            HashCode.Combine(Numerator, Denominator);

        public int CompareTo(Rational other)
        {
            long lhs = (long)Numerator * other.Denominator;
            long rhs = (long)other.Numerator * Denominator;
            return lhs.CompareTo(rhs);
        }

        public override string ToString() =>
            $"{Numerator}/{Denominator}";
    }
}