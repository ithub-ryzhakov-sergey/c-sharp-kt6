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

            // Нормализация знака: знак только у числителя
            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }

            // Сокращение дроби с помощью алгоритма Евклида
            int gcd = Gcd(Math.Abs(numerator), Math.Abs(denominator));
            if (gcd == 0) gcd = 1; // Защита от нуля (если оба нули — но это невозможно по условию)

            Numerator = numerator / gcd;
            Denominator = denominator / gcd;
        }

        private static int Gcd(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Rational other && Equals(other);
        }

        public bool Equals(Rational other)
        {
            return Numerator == other.Numerator && Denominator == other.Denominator;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Numerator, Denominator);
        }

        public int CompareTo(Rational other)
        {
            // Сравнение a/b и c/d → a*d и c*b (с учётом переполнения)
            long left = (long)Numerator * other.Denominator;
            long right = (long)other.Numerator * Denominator;
            return left.CompareTo(right);
        }

        // Операторы
        public static Rational operator +(Rational a, Rational b)
        {
            long num = (long)a.Numerator * b.Denominator + (long)b.Numerator * a.Denominator;
            long den = (long)a.Denominator * b.Denominator;
            return new Rational((int)num, (int)den);
        }

        public static Rational operator -(Rational a, Rational b)
        {
            long num = (long)a.Numerator * b.Denominator - (long)b.Numerator * a.Denominator;
            long den = (long)a.Denominator * b.Denominator;
            return new Rational((int)num, (int)den);
        }

        public static Rational operator *(Rational a, Rational b)
        {
            long num = (long)a.Numerator * b.Numerator;
            long den = (long)a.Denominator * b.Denominator;
            return new Rational((int)num, (int)den);
        }

        public static Rational operator /(Rational a, Rational b)
        {
            if (b.Numerator == 0)
                throw new DivideByZeroException("Cannot divide by zero rational.");

            long num = (long)a.Numerator * b.Denominator;
            long den = (long)a.Denominator * b.Numerator;

            return new Rational((int)num, (int)den);
        }
    }
}