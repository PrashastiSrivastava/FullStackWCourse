using _8_Async_Await_Data_Dashboard;
using System;
using System.Threading.Tasks;

namespace _8_Async_Await_Data_Dashboard {
    class Program {
        static async Task Main(string[] args) {
            Console.WriteLine("=== ASYNC/AWAIT DASHBOARD DEMO ===\n");

            var dashboard = new Dashboard();

            // UI remains responsive while loading
            dashboard.ShowResponsiveUI();

            Console.WriteLine("⏰ Starting API call at: " + DateTime.Now.ToString("HH:mm:ss"));

            // This doesn't block - other code can run
            Task loadTask = dashboard.LoadAndDisplayDataAsync();

            // Simulate UI doing other work while waiting
            for (int i = 1; i <= 3; i++) {
                await Task.Delay(500);
                Console.WriteLine($"🔄 UI Task {i} - Still working while waiting for API...");
            }

            await loadTask; // Wait for completion

            Console.WriteLine("\n⏰ Completed at: " + DateTime.Now.ToString("HH:mm:ss"));
            Console.WriteLine("\n✨ Dashboard ready! (Non-blocking demo successful)");
        }
    }
}