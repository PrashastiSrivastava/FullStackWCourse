using _3_Events_OrderProcessingSystem.EventArgs;

namespace _3_Events_OrderProcessingSystem.Subscribers {
    public class NotificationService {
        public void OnOrderPlaced(object sender, OrderPlacedEventArgs e) {
            Console.WriteLine($"  📧 SMS sent to {e.CustomerName} for ₹{e.TotalAmount}");
        }
    }
}