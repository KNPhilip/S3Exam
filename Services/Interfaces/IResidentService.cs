namespace Services.Interfaces
{
    public interface IResidentService<TEntity> : ISOSUService<TEntity> where TEntity : class
    {
        Task<List<Resident>> GetAllResidentsAsync();
    }
}