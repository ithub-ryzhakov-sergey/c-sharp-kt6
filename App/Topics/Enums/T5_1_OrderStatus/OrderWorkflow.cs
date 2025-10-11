using System;

namespace App.Topics.Enums.T5_1_OrderStatus
{
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
                OrderStatus.Delivered => throw new InvalidOperationException("Order is already delivered."),
                OrderStatus.Cancelled => throw new InvalidOperationException("Order is cancelled."),
                _ => throw new InvalidOperationException("Unknown order status.")
            };
        }

        public static OrderStatus Parse(string text)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Value cannot be empty or whitespace.", nameof(text));

            // Попытка разобрать без учёта регистра
            if (Enum.TryParse<OrderStatus>(text, ignoreCase: true, out OrderStatus result))
            {
                return result;
            }

            throw new ArgumentException($"'{text}' is not a valid OrderStatus.", nameof(text));
        }
    }
}