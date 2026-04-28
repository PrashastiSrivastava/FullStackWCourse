using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _8_Async_Await_Data_Dashboard {
    public class ApiService {
        // Simulates API call to fetch Indian names
        public async Task<List<string>> FetchDataFromAPIAsync() {
            await Task.Delay(2000); // Simulates network delay

            // Sample Indian first names
            var names = new List<string>
            {
                "Aarav", "Vihaan", "Vivaan", "Ananya", "Diya",
                "Advik", "Kabir", "Ishaan", "Sai", "Pari"
            };

            return names;
        }
    }
}