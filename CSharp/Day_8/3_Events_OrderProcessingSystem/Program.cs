using _3_Events_OrderProcessingSystem.Models;
using _3_Events_OrderProcessingSystem.Publisher;
using _3_Events_OrderProcessingSystem.Subscribers;
using _3_Events_OrderProcessingSystem.EventArgs;

namespace _3_Events_OrderProcessingSystem {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("=== ORDER PROCESSING SYSTEM ===\n");

            // Create publisher and subscribers
            OrderProcessor orderProcessor = new OrderProcessor();
            NotificationService notificationService = new NotificationService();
            InventoryService inventoryService = new InventoryService();
            LoggingService loggingService = new LoggingService();

            // Subscribe to event
            orderProcessor.OrderPlaced += notificationService.OnOrderPlaced;
            orderProcessor.OrderPlaced += inventoryService.OnOrderPlaced;
            orderProcessor.OrderPlaced += loggingService.OnOrderPlaced;

            // Create orders with Indian names
            Order[] orders = {
                new Order(101, "Arjun", 1500m),
                new Order(102, "Kavya", 750m),
                new Order(103, "Rohan", 2200m),
                new Order(104, "Divya", 600m),
                new Order(105, "Manish", 1800m)
            };

            // Process all orders
            foreach (var order in orders) {
                Console.WriteLine($"\n▶ Processing Order #{order.OrderId} - {order.CustomerName}");
                orderProcessor.ProcessOrder(order);
            }

            // Unsubscribe logging and process one more
            Console.WriteLine("\n--- Removing LoggingService ---");
            orderProcessor.OrderPlaced -= loggingService.OnOrderPlaced;

            Order lastOrder = new Order(106, "Pooja", 950m);
            Console.WriteLine($"\n▶ Processing Order #{lastOrder.OrderId} - {lastOrder.CustomerName} (No Logging)");
            orderProcessor.ProcessOrder(lastOrder);

            Console.WriteLine("\n=== All Orders Processed ===");
            Console.ReadKey();
        }
    }
}