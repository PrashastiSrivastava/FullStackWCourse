using System;
using _4_Real_Time_Order_Notification_System.Services;

namespace _4_Real_Time_Order_Notification_System {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("===============================================");
            Console.WriteLine("  REAL-TIME ORDER NOTIFICATION SYSTEM");
            Console.WriteLine("===============================================");

            // Create processor and services
            OrderProcessor processor = new OrderProcessor();
            EmailService emailService = new EmailService();
            SMSService smsService = new SMSService();
            LoggerService loggerService = new LoggerService();

            // ========== DEMONSTRATION 1: Subscribing all services ==========
            Console.WriteLine("\n\n--- PART 1: All Services Subscribed ---");

            // Subscribe to event (Multicast Delegate)
            processor.OnOrderPlaced += emailService.SendEmail;
            processor.OnOrderPlaced += smsService.SendSMS;
            processor.OnOrderPlaced += loggerService.LogOrder;

            Console.WriteLine($"Active subscribers: {processor.GetSubscriberCount()}");

            // Process first order
            Order order1 = new Order
            {
                OrderId = 1001,
                CustomerName = "Arjun Mehta",
                Amount = 1250.75
            };
            processor.ProcessOrder(order1);

            // ========== DEMONSTRATION 2: Dynamic Unsubscription ==========
            Console.WriteLine("\n\n--- PART 2: After Removing SMS Service ---");

            // Unsubscribe SMS service dynamically
            processor.OnOrderPlaced -= smsService.SendSMS;
            Console.WriteLine($"Active subscribers: {processor.GetSubscriberCount()}");

            // Process second order
            Order order2 = new Order
            {
                OrderId = 1002,
                CustomerName = "Kavita Desai",
                Amount = 3499.99
            };
            processor.ProcessOrder(order2);

            // ========== DEMONSTRATION 3: Using Action<> Delegate (Bonus) ==========
            Console.WriteLine("\n\n--- PART 3: Using Action<> Delegate (Bonus Feature) ---");

            // Alternative way using built-in Action delegate
            Action<Order> actionNotification = null;
            actionNotification += emailService.SendEmail;
            actionNotification += loggerService.LogOrder;

            Console.WriteLine("Using Action<> delegate to send notifications:");
            Order order3 = new Order
            {
                OrderId = 1003,
                CustomerName = "Sunil Kumar",
                Amount = 899.99
            };
            actionNotification?.Invoke(order3);

            // ========== DEMONSTRATION 4: Resubscribing (Final Order) ==========
            Console.WriteLine("\n\n--- PART 4: Resubscribed SMS Service (Final Order) ---");

            // Resubscribe SMS
            processor.OnOrderPlaced += smsService.SendSMS;
            Console.WriteLine($"Active subscribers: {processor.GetSubscriberCount()}");

            Order order4 = new Order
            {
                OrderId = 1004,
                CustomerName = "Priyanka Reddy",
                Amount = 2750.00
            };
            processor.ProcessOrder(order4);

            Console.WriteLine("\n===============================================");
            Console.WriteLine("  TOTAL ORDERS PROCESSED: 4");
            Console.WriteLine("  PRESS ANY KEY TO EXIT");
            Console.WriteLine("===============================================");
            Console.ReadKey();
        }
    }
}