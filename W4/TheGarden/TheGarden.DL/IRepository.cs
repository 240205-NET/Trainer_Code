using TheGarden.BL;

namespace TheGarden.DL
{
    public interface IRepository
    {
        public Task EnterNewPlantAsync(Plant newPlant);
        public Task<IEnumerable<Plant>> GetAllPlantsAsync();
        public Task<Plant> GetPlantByIdAsync(int id);

    }
}
