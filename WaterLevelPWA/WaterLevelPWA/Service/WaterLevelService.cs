using System.Net;
using WaterLevelPWA.DTO;

namespace WaterLevelPWA.Service
{
    public class WaterLevelService : IWaterLevelService
    {
        private readonly HttpClient _http;
        public WaterLevelService(HttpClient http) => _http = http;

        public async Task<WaterLevelDTO?> GetLevelAsync(string deviceId)
        {
            var response = await _http.GetAsync(
                $"api/WaterLevel?deviceId={Uri.EscapeDataString(deviceId)}");

            // 404 = ainda não há leituras para esse dispositivo; não é erro fatal
            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<WaterLevelDTO>();
        }
    }
}
