// Тема 5, Задача T5.1_OrderStatus
// Проектирование enum и функций переходов состояний заказа.

namespace App.Topics.Enums.T5_1_OrderStatus;

public enum OrderStatus { New, Paid, Shipped, Delivered, Cancelled};

public static class OrderWorkflow
{
    public static bool CanTransition(OrderStatus from, OrderStatus to)
    {
        if (from == OrderStatus.New && to == OrderStatus.Paid) { return true; }
        if (from == OrderStatus.Paid && to == OrderStatus.Shipped) { return true; }
        if (from == OrderStatus.Shipped && to == OrderStatus.Delivered) { return true; }
        if ((from == OrderStatus.New || from == OrderStatus.Paid || from == OrderStatus.Shipped) && to == OrderStatus.Cancelled) { return true; }
        return false;
    }
    public static OrderStatus Next(OrderStatus current)
    {
        if (current == OrderStatus.Delivered || current == OrderStatus.Cancelled)
        {
            throw new InvalidOperationException();
        }
        return (OrderStatus)((int)current + 1);
    }
    public static OrderStatus Parse(string text)
    {
        if (string.IsNullOrEmpty(text)) {
            throw new ArgumentNullException();
        }
        int index = 0;
        foreach (var item in Enum.GetNames(typeof(OrderStatus)))
        {
            if (item.ToLower() == text.ToLower())
            {
                return (OrderStatus)index;
            }
            index++;
        }
        throw new ArgumentException();
    }
}