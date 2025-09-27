using System;

namespace App.Topics.Structs.T3_2_Rational_Advanced
{
    public readonly struct Rational : IEquatable<Rational>, IComparable<Rational>
    {
        public int Numerator { get; }
        public int Denominator { get; }

        public Rational(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new DivideByZeroException("Denominator cannot be zero.");

            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }

            int gcd = GreatestCommonDivisor(Math.Abs(numerator), Math.Abs(denominator));
            Numerator = numerator / gcd;
            Denominator = denominator / gcd;
        }

        private static int GreatestCommonDivisor(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public static Rational operator +(Rational a, Rational b)
        {
            int numerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
            int denominator = a.Denominator * b.Denominator;
            return new Rational(numerator, denominator);
        }

        public static Rational operator -(Rational a, Rational b)
        {
            int numerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
            int denominator = a.Denominator * b.Denominator;
            return new Rational(numerator, denominator);
        }

        public static Rational operator *(Rational a, Rational b)
        {
            int numerator = a.Numerator * b.Numerator;
            int denominator = a.Denominator * b.Denominator;
            return new Rational(numerator, denominator);
        }

        public static Rational operator /(Rational a, Rational b)
        {
            if (b.Numerator == 0)
                throw new DivideByZeroException("Division by zero rational number.");

            int numerator = a.Numerator * b.Denominator;
            int denominator = a.Denominator * b.Numerator;
            return new Rational(numerator, denominator);
        }

        public bool Equals(Rational other)
        {
            return Numerator == other.Numerator && Denominator == other.Denominator;
        }

        public override bool Equals(object? obj)
        {
            return obj is Rational other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Numerator, Denominator);
        }

        public int CompareTo(Rational other)
        {
            long left = (long)Numerator * other.Denominator;
            long right = (long)other.Numerator * Denominator;
            return left.CompareTo(right);
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public static bool operator ==(Rational left, Rational right) => left.Equals(right);
        public static bool operator !=(Rational left, Rational right) => !left.Equals(right);
        public static bool operator <(Rational left, Rational right) => left.CompareTo(right) < 0;
        public static bool operator >(Rational left, Rational right) => left.CompareTo(right) > 0;
        public static bool operator <=(Rational left, Rational right) => left.CompareTo(right) <= 0;
        public static bool operator >=(Rational left, Rational right) => left.CompareTo(right) >= 0;
    }
}