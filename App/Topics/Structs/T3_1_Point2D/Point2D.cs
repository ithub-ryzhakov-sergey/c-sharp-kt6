// Тема 3, Задача T3.1_Point2D
// Базовая практика со структурами (value type).

using System.Drawing;

namespace App.Topics.Structs.T3_1_Point2D;

public readonly struct Point2D
{
    public double X { get; }
    public double Y { get; }
    public Point2D(double x, double y)
    {
        X = x; Y = y;
    }
    public double Length
    {
        get
        {
            return Math.Sqrt(X * X + Y * Y);
        }
    }
    public Point2D Add(in Point2D other)
    {
        return new Point2D(other.X + X, other.Y + Y);
    }
    public Point2D Subtract(in Point2D other)
    {
        return new Point2D(X - other.X, Y - other.Y);
    }
    public double DistanceTo(in Point2D other)
    {
        return Math.Sqrt(Math.Pow(other.X - X, 2) + Math.Pow(other.Y - Y, 2));
    }
    public override bool Equals(object? obj) {
        if (obj is Point2D _obj) {
            if (this.X == _obj.X && this.Y == _obj.Y)
            {
                return true;
            }
        }
        return false;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y); // made in Chatgpt
    }
}