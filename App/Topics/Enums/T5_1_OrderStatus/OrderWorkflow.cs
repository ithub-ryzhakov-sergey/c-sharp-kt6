// Тема 5, Задача T5.1_OrderStatus
// Проектирование enum и функций переходов состояний заказа.

using System.Net.WebSockets;

namespace App.Topics.Enums.T5_1_OrderStatus;


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
        if (to == OrderStatus.Cancelled)
        {
            return true;
        }

        var next = TryGetNext(from);
        return next != null && next == to;
}


    public static OrderStatus Next(OrderStatus current)
    {
        var next = TryGetNext(current);
        if (next == null)
        {
            throw new InvalidOperationException();
        }

        return next.Value;
    }

    private static OrderStatus? TryGetNext(OrderStatus current)
    {
        return current switch
        {
            OrderStatus.New => OrderStatus.Paid,
            OrderStatus.Paid => OrderStatus.Shipped,
            OrderStatus.Shipped => OrderStatus.Delivered,
            OrderStatus.Delivered => null,
            OrderStatus.Cancelled => null,
        };
    }


    public static OrderStatus Parse(string text)
    {
        if (text == null)
            throw new ArgumentNullException("text");

        return Enum.TryParse(typeof(OrderStatus),text, ignoreCase: true, out var value)
            ? (OrderStatus)value
            : throw new System.ArgumentException();
    }

}


