namespace _3_Events_OrderProcessingSystem.EventArgs {
    public class OrderPlacedEventArgs : System.EventArgs {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime OrderDate { get; set; }

        public OrderPlacedEventArgs(int orderId, string customerName, decimal totalAmount) {
            OrderId = orderId;
            CustomerName = customerName;
            TotalAmount = totalAmount;
            OrderDate = DateTime.Now;
        }
    }
}