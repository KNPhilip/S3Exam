namespace Services.Interfaces
{
    public interface IAssignmentService
    {
        Task<ObservableCollection<Assignment>> GetAllAssignmentsAsync();
    }
}