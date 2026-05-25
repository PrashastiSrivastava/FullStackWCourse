using _8_Async_Await_Data_Dashboard;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _8_Async_Await_Data_Dashboard {
    public class Dashboard {
        private readonly ApiService _apiService;

        public Dashboard() {
            _apiService = new ApiService();
        }

        // Non-blocking method - UI stays responsive
        public async Task LoadAndDisplayDataAsync() {
            Console.WriteLine("📊 Dashboard Loading...");
            Console.WriteLine("⏳ Fetching data from API (UI is responsive)...\n");

            // This doesn't block - control returns to caller
            List<string> names = await _apiService.FetchDataFromAPIAsync();

            Console.WriteLine("✅ Data received!\n");
            Console.WriteLine("Indian First Names:");
            Console.WriteLine("------------------");

            for (int i = 0; i < names.Count; i++) {
                await Task.Delay(100); // Simulates progressive display
                Console.WriteLine($"{i + 1}. {names[i]}");
            }

            Console.WriteLine($"\n📈 Total {names.Count} names loaded.");
        }

        // Simulates other UI work that can happen while waiting for API
        public void ShowResponsiveUI() {
            Console.WriteLine("🎨 Dashboard UI is responsive!");
            Console.WriteLine("💡 You can do other tasks while waiting for API...\n");
        }
    }
}