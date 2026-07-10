using System.Net.Http.Json;
using WaterLevelPWA.DTO;

namespace WaterLevelPWA.Service
{
    public class WaterLevelService : IWaterLevelService
    {
        private readonly HttpClient _http;
        public WaterLevelService(HttpClient http) => _http = http;

        public async Task<WaterLevelDTO?> GetLevelAsync()
            => await _http.GetFromJsonAsync<WaterLevelDTO>("api/WaterLevel");

        public async Task<WaterLevelDTO?> SetLevelAsync(string deviceId, double minLevel, double maxLevel, double currentLevel)
        {
            var response = await _http.PostAsJsonAsync("api/WaterLevel", new WaterLevelDTO
            {
                DeviceId = deviceId,
                MinLevel = minLevel,
                MaxLevel = maxLevel,
                CurrentLevel = currentLevel
            });
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<WaterLevelDTO>();
        }
    }
}
