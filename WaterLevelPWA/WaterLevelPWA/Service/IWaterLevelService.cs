using WaterLevelPWA.DTO;

namespace WaterLevelPWA.Service
{
    public interface IWaterLevelService
    {
        Task<WaterLevelDTO?> GetLevelAsync(int deviceId);
    }
}
