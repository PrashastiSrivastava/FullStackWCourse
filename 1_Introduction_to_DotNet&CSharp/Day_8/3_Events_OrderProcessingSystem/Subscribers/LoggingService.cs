using _3_Events_OrderProcessingSystem.EventArgs;

namespace _3_Events_OrderProcessingSystem.Subscribers {
    public class LoggingService {
        public void OnOrderPlaced(object sender, OrderPlacedEventArgs e) {
            Console.WriteLine($"  📝 Order #{e.OrderId} logged");
        }
    }
}