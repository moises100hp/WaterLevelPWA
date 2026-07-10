using WaterLevelPWA.DTO;

namespace WaterLevelPWA.Service
{
    public interface IWaterLevelService
    {
        Task<WaterLevelDTO?> GetLevelAsync();
        Task<WaterLevelDTO?> SetLevelAsync(string deviceId, double minLevel, double maxLevel, double currentLevel);
    }
}
