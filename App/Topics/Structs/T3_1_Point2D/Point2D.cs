// Тема 3, Задача T3.1_Point2D
// Базовая практика со структурами (value type).

namespace App.Topics.Structs.T3_1_Point2D;

public readonly struct Point2D
{
    public double X { get; }
    public double Y { get; }

    public Point2D(double x, double y)
    {
        X = x;
        Y = y;
    }
    public double Length => Math.Sqrt(X * X + Y * Y);

    public Point2D Add(Point2D other)
    {
        return new Point2D(X + other.X, Y + other.Y);
    }
    public Point2D Subtract(Point2D other)
    {
        return new Point2D(X - other.X, Y - other.Y);
    }
    public double DistanceTo(Point2D other)
    {
        double dx = X - other.X;
        double dy = Y - other.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }
    public override bool Equals(object? obj)
    {
        return obj is Point2D other && Equals(other);
    }
    public bool Equals(Point2D other)
    {
        return X == other.X && Y == other.Y;
    }
    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + X.GetHashCode();
            hash = hash * 23 + Y.GetHashCode();
            return hash;
        }
    }
}
