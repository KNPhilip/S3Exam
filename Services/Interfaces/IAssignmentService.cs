using Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAssignmentService
    {
        Task<ObservableCollection<Assignment>> GetAllAssignmentsAsync();
    }
}