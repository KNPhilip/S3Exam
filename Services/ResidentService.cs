namespace Services
{
    public class ResidentService : SOSUService<Resident>, IResidentService<Resident>
    {
        public async Task<List<Resident>> GetAllResidentsAsync()
        {
            return await DoHttpGetRequest("Resident/GetResidents");
        }
    }
}