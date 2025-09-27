namespace App.Topics.Enums.T5_1_OrderStatus;
using System;

public enum OrderStatus
{
    New,
    Paid,
    Shipped,
    Delivered,
    Cancelled
}

public static class OrderWorkflow
{
    public static bool CanTransition(OrderStatus from, OrderStatus to)
    {
        return (from, to) switch
        {
            (OrderStatus.New, OrderStatus.Paid) => true,
            (OrderStatus.Paid, OrderStatus.Shipped) => true,
            (OrderStatus.Shipped, OrderStatus.Delivered) => true,
            (OrderStatus.New, OrderStatus.Cancelled) => true,
            (OrderStatus.Paid, OrderStatus.Cancelled) => true,
            (OrderStatus.Shipped, OrderStatus.Cancelled) => true, _ => false
        };
    }

    public static OrderStatus Next(OrderStatus current)
    {
        return current switch
        {
            OrderStatus.New => OrderStatus.Paid,
            OrderStatus.Paid => OrderStatus.Shipped,
            OrderStatus.Shipped => OrderStatus.Delivered,
            OrderStatus.Delivered => throw new InvalidOperationException("Delivered конечный статус"),
            OrderStatus.Cancelled => throw new InvalidOperationException("Cancelled конечный статус."),
            _ => throw new ArgumentOutOfRangeException(nameof(current), "неизвестный статус")
        };
    }

    public static OrderStatus Parse(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            throw new ArgumentNullException(nameof(text), "статус не может быть пустым или null");

        if (Enum.TryParse<OrderStatus>(text, true, out var status))
            return status;

        throw new ArgumentException($"неизвестый статус заказа: {text}", nameof(text));
    }
}