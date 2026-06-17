using System;


public class InventoryService
{
    public bool CheckStock(string item)
    {
        Console.WriteLine($"Checking if {item} is in stock");

        return true;
    }
}

public class PaymentService
{
    public bool ProcessPayment(string paymentDetails)
    {
        Console.WriteLine($"Processing payment with details: {paymentDetails}");

        return true;
    }
}

public class ShippingService
{
    public void ShipItem(string item, string shippingAddress)
    {
        Console.WriteLine($"Shipping {item} to {shippingAddress}");
    }
}

public class NotificationService
{
    public void Notify(string message)
    {
        Console.WriteLine($"Sending notification: {message}");
    }
}

public class OrderFacade
{
    private InventoryService _inventoryService;
    private PaymentService _paymentService;
    private ShippingService _shippingService;
    private NotificationService _notificationService;

    public OrderFacade()
    {
        _inventoryService = new InventoryService();
        _paymentService = new PaymentService();
        _shippingService = new ShippingService();
        _notificationService = new NotificationService();
    }

    public void PlaceOrder(string item, string paymentDetails, string shippingAddress)
    {
        if (_inventoryService.CheckStock(item))
        {
            if (_paymentService.ProcessPayment(paymentDetails))
            {
                _shippingService.ShipItem(item, shippingAddress);
                _notificationService.Notify("Your order has been placed successfully");
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        OrderFacade orderFacade = new OrderFacade();
        orderFacade.PlaceOrder("Laptop", "Credit Card", "123 Main St");
    }
}