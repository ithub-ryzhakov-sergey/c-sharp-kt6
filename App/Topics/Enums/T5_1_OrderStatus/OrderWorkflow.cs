// Тема 5, Задача T5.1_OrderStatus
// Проектирование enum и функций переходов состояний заказа.

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
            (OrderStatus.Shipped, OrderStatus.Cancelled) => true,
            _ => false
        };
    }

    public static OrderStatus Next(OrderStatus current)
    {
        return current switch
        {
            OrderStatus.New => OrderStatus.Paid,
            OrderStatus.Paid => OrderStatus.Shipped,
            OrderStatus.Shipped => OrderStatus.Delivered,
            OrderStatus.Delivered => throw new InvalidOperationException(),
            OrderStatus.Cancelled => throw new InvalidOperationException(),
            _ => throw new ArgumentOutOfRangeException(nameof(current))
        };
    }

    public static OrderStatus Parse(string text)
    {
        if (text == null)
            throw new ArgumentNullException(nameof(text));

        if (string.IsNullOrWhiteSpace(text))
            throw new ArgumentException(nameof(text));

        if (Enum.TryParse<OrderStatus>(text, true, out var result))
        {
            return result;
        }

        throw new ArgumentException(nameof(text));
    }
}