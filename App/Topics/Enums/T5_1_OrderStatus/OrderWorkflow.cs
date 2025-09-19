// Тема 5, Задача T5.1_OrderStatus
// Проектирование enum и функций переходов состояний заказа.

namespace App.Topics.Enums.T5_1_OrderStatus;

public enum OrderStatus
{
    New = 0,
    Paid = 1,
    Shipped = 2,
    Delivered = 3,
    Cancelled = 4
}

public static class OrderWorkflow
{
    public static bool CanTransition(OrderStatus from, OrderStatus to)
    {
        // Допустимые переходы: New->Paid, Paid->Shipped, Shipped->Delivered, New->Cancelled, Paid->Cancelled, Shipped->Cancelled
        // Переход из Delivered/Cancelled запрещён.
        throw new NotImplementedException();
    }

    public static OrderStatus Next(OrderStatus current)
    {
        // Возвращает следующий статус по цепочке (New->Paid->Shipped->Delivered). Для Delivered/Cancelled — InvalidOperationException.
        throw new NotImplementedException();
    }

    public static OrderStatus Parse(string text)
    {
        // Регистронезависимый разбор строк: "new", "paid", ... Неизвестное — ArgumentException, null/empty — ArgumentNullException.
        throw new NotImplementedException();
    }
}
