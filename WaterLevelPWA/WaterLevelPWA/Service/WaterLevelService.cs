using WaterLevelPWA.DTO;

namespace WaterLevelPWA.Service
{
    public class WaterLevelService : IWaterLevelService
    {
        private readonly HttpClient _http;
        public WaterLevelService(HttpClient http) => _http = http;

        public async Task<WaterLevelDTO?> GetLevelAsync()
            => await _http.GetFromJsonAsync<WaterLevelDTO>("api/WaterLevel");
    }
}
