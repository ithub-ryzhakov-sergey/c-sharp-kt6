// Тема 3, Задача T3.1_Point2D
// Базовая практика со структурами (value type).

namespace App.Topics.Structs.T3_1_Point2D;

public readonly struct Point2D
{
    public double X { get; }
    public double Y { get; }
    public double Length => Math.Sqrt(X * X + Y * Y);

    public Point2D(double x, double y)
    {
        this.X = x;
        this.Y = y;
    }

    public Point2D Add(Point2D other)
    {
        return new Point2D(this.X + other.X, this.Y + other.Y);
    }

    public Point2D Subtract(Point2D other)
    {
        return new Point2D(this.X - other.X, this.Y - other.Y);
    }

    public double DistanceTo(Point2D other)
    {
        return Math.Sqrt((other.X - this.X) * (other.X - this.X) + (other.Y - this.Y) * (other.Y - this.Y));
    }

    public override bool Equals(object? obj)
    {
        return obj is Point2D other
            && this.X == other.X
            && this.Y == other.Y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this.X, this.Y);
    }
}
