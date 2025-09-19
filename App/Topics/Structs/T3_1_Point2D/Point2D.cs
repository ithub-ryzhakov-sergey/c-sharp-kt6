// Тема 3, Задача T3.1_Point2D
// Базовая практика со структурами (value type).

namespace App.Topics.Structs.T3_1_Point2D;

public readonly struct Point2D
{
    // Подсказка: иммутабельность через init-only/readonly поля
    public double X { get; }
    public double Y { get; }

    public Point2D(double x, double y)
    {
        // Сохраните координаты
        throw new NotImplementedException();
    }

    public double Length => throw new NotImplementedException();

    public Point2D Add(in Point2D other) => throw new NotImplementedException();
    public Point2D Subtract(in Point2D other) => throw new NotImplementedException();

    public double DistanceTo(in Point2D other) => throw new NotImplementedException();

    public override bool Equals(object? obj) => throw new NotImplementedException();
    public override int GetHashCode() => throw new NotImplementedException();
}
